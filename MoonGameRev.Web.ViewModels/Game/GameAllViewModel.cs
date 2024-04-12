using System.ComponentModel.DataAnnotations;

namespace MoonGameRev.Web.ViewModels.Game
{
    public class GameAllViewModel
    {
        public string Id { get; set; } 

        public string Title { get; set; } = null!;

        [Display(Name ="Image Link")]
        public string ImageUrl { get; set; } = null!;

        public double Rating { get; set; }
    }
}
