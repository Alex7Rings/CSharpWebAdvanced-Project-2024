using MoonGameRev.Web.ViewModels.News;
using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.GeneralApplicationConstants;

namespace MoonGameRev.Web.ViewModels.Game
{
    public class UpcomingGamesQueryModel
    {
        public UpcomingGamesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.GamesPerPage = EntitiesPerPage;
            this.UpcomingGames = new HashSet<UpcomingGamesViewModel>();
        }

        public int CurrentPage { get; set; }

        public int GamesPerPage { get; set; }

        public int TotalGames { get; set; }

        public IEnumerable<UpcomingGamesViewModel> UpcomingGames { get; set; }
    }
}
