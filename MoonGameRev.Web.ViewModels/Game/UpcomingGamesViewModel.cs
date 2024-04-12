using System.ComponentModel.DataAnnotations;

namespace MoonGameRev.Web.ViewModels.Game
{
    public class UpcomingGamesViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; } = null!;

        [Display(Name = "Image Link")]
        public string PictureUrl { get; set; } = null!;

        public DateTime ReleasDate { get; set; }
    }
    
}
