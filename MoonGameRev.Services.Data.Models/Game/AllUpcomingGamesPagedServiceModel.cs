namespace MoonGameRev.Services.Data.Models.Game
{
    using MoonGameRev.Web.ViewModels.Game;

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
