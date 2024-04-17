namespace MoonGameRev.Services.Data.Models.Game
{
    using MoonGameRev.Web.ViewModels.Game;

    public class AllGamesFilteredAndPagedServiceModel
    {
        public AllGamesFilteredAndPagedServiceModel()
        {
            this.Games = new HashSet<GameAllViewModel>();
        }

        public int TotalGamesCount { get; set; }

        public IEnumerable<GameAllViewModel> Games { get; set; }
    }
}
