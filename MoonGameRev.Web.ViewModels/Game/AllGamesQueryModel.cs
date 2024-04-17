namespace MoonGameRev.Web.ViewModels.Game
{
    using MoonGameRev.Web.ViewModels.Game.Enums;
    using System.ComponentModel.DataAnnotations;
    using static MoonGameRev.Common.GeneralApplicationConstants;


    public class AllGamesQueryModel
    {
        public AllGamesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.GamesPerPage = EntitiesPerPage;

            this.Genres = new HashSet<string>();
            this.Games = new HashSet<GameAllViewModel>();
        }

        public string? Genre { get; set; }

        [Display(Name = "Search by name")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Games By")]
        public GameSorting GameSorting { get; set; }

        public int CurrentPage { get; set; }

        public int GamesPerPage { get; set; }

        public int TotalGames { get; set; }

        public IEnumerable<string> Genres { get; set; } = null!;

        public IEnumerable<GameAllViewModel> Games { get; set; }
    }
}
