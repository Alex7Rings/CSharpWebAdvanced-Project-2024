using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Home;

namespace MoonGameRev.Services.Data
{
    public class GameService : IGameService
    {
        private readonly MoonGameRevDbContext dbContext;

        public GameService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                .OrderByDescending(x => x.Id)
                .Take(5)
                .Select(g => new IndexViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.CoverImage,
                    IsReleased = g.IsReleased == false,
                })
                .ToArrayAsync();
            return lastUpcomingFiveGames;
        }
    }
}
