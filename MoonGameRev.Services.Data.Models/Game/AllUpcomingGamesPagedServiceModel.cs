using MoonGameRev.Web.ViewModels.Game;

namespace MoonGameRev.Services.Data.Models.Game
{
    public class AllUpcomingGamesPagedServiceModel
    {
        public AllUpcomingGamesPagedServiceModel()
        {
            this.UpcomingGames = new HashSet<UpcomingGamesViewModel>();
        }

        public int TotalUpcomingGames { get; set; }

        public IEnumerable<UpcomingGamesViewModel> UpcomingGames { get; set; }
    }
}
