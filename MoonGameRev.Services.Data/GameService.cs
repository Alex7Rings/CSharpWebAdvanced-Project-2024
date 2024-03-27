using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data.Models.Game;
using MoonGameRev.Web.ViewModels.Game;
using MoonGameRev.Web.ViewModels.Game.Enums;
using MoonGameRev.Web.ViewModels.Home;
using System.Globalization;

namespace MoonGameRev.Services.Data
{
    public class GameService : IGameService
    {
        private readonly MoonGameRevDbContext dbContext;

        public GameService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllGamesFilteredAndPagedServiceModel> AllAsync(AllGamesQueryModel queryModel)
        {
            IQueryable<Game> gamesQuery = this.dbContext
                .Games
                .Include(g => g.GameGenres)
                .ThenInclude(gg => gg.Genre) // Include Genre navigation property
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Genre))
            {
                gamesQuery = gamesQuery
                    .Where(g => g.GameGenres.Any(gg => gg.Genre.Name == queryModel.Genre));
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                gamesQuery = gamesQuery
                    .Where(g => EF.Functions.Like(g.Title, wildCard) ||
                                EF.Functions.Like(g.Description, wildCard));
            }

            gamesQuery = queryModel.GameSorting switch
            {
                GameSorting.Newest => gamesQuery
                    .OrderByDescending(g => g.ReleaseDate),
                GameSorting.Oldest => gamesQuery
                    .OrderBy(g => g.ReleaseDate),
                GameSorting.Rating => gamesQuery
                    .OrderBy(g => g.Reviews.Average(r => r.Rating)),
                _ => gamesQuery.OrderByDescending(g => g.Id)
            };

            IEnumerable<GameAllViewModel> allGames = await gamesQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.GamesPerPage)
                .Take(queryModel.GamesPerPage)
                .Select(g => new GameAllViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.CoverImage,
                    Rating = g.Reviews.Any() ? g.Reviews.Average(r => r.Rating) : 0, // Calculate average rating if there are reviews
                })
                .ToArrayAsync();

            int totalGames = gamesQuery.Count();

            return new AllGamesFilteredAndPagedServiceModel()
            {
                TotalGamesCount = totalGames,
                Games = allGames
            };
        }

        public async Task CreateAsync(GameFormModel formModel)
        {
            string dateTimeString = $"{formModel.ReleaseDate}";
            if (!DateTime.TryParseExact(dateTimeString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime persedDateTime))
            {
                throw new InvalidOperationException("Invalid date or time format");
            }


            Game newGame = new Game()
            {
                Title = formModel.Title,
                Description = formModel.Description,
                Developer = formModel.Developer,
                Publisher = formModel.Publisher,
                GameSite = formModel.GameSite,
                ReleaseDate = persedDateTime,
                CoverImage = formModel.CoverImage,
                IsReleased = formModel.IsReleased,                
            };

            await this.dbContext.Games.AddAsync(newGame);
            await this.dbContext.SaveChangesAsync();

            foreach (var genreId in formModel.GenreIds)
            {
                var gameGenre = new GameGenre
                {
                    GameID = newGame.Id, // Use the ID of the newly created game
                    GenreID = genreId
                };
                // Add the new GameGenre entry to the database
                await this.dbContext.GameGenres.AddAsync(gameGenre);
            }
            // Save changes to persist the new GameGenre entries
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexViewModel>> LastFiveGamesAsync()
        {
            IEnumerable<IndexViewModel> lastFiveGames = await this.dbContext
                .Games
                .OrderByDescending(x => x.Id)
                .Take(5)
                .Select(g=> new IndexViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.CoverImage,
                    IsReleased = g.IsReleased == true,
                })
                .ToArrayAsync();
            return lastFiveGames;
        }

        public async Task<IEnumerable<IndexViewModel>> LastFiveUpcomingGamesAsync()
        {
            IEnumerable<IndexViewModel> lastUpcomingFiveGames = await this.dbContext
                .Games
                .Where(g=>g.IsReleased== false)
                .OrderByDescending(x => x.Id)
                .Take(5)
                .Select(g => new IndexViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.CoverImage,
                    IsReleased = g.IsReleased,
                })
                .ToArrayAsync();
            return lastUpcomingFiveGames;
        }
    }
}
