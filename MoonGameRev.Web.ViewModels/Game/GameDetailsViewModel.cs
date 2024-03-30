using MoonGameRev.Web.ViewModels.Review;
using System.ComponentModel.DataAnnotations;

namespace MoonGameRev.Web.ViewModels.Game
{
    public class GameDetailsViewModel : GameAllViewModel
    {
        public string Description { get; set; } = null!;

        public string Developer { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public string GameSite { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public List<string> Genres { get; set; } = new List<string>();

        public List<ReviewDetailsViewModel> Reviews { get; set; } = new List<ReviewDetailsViewModel>();
    }
}
