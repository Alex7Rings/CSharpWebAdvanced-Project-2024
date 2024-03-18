using MoonGameRev.Web.ViewModels.Home;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveUpcomingGamesAsync();

        Task<IEnumerable<IndexViewModel>> LastFiveGamesAsync();
    }
}
