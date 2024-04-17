namespace MoonGameRev.Web.ViewModels.Game
{
    using MoonGameRev.Web.ViewModels.Review;

    public class GameDetailsViewModel : GameAllViewModel
    {
        public string Description { get; set; } = null!;

        public string Developer { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public string GameSite { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public bool IsReleased { get; set; }

        public List<string> Genres { get; set; } = new List<string>();

        public List<ReviewDetailsViewModel> Reviews { get; set; } = new List<ReviewDetailsViewModel>();

        public double AverageRating { get; set; }

        public string RatingCategory { get; set; }
    }
}
