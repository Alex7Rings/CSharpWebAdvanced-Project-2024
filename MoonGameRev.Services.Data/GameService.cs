using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Game;
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
