using System.ComponentModel.DataAnnotations;

namespace MoonGameRev.Web.ViewModels.News
{
    public class NewsPreDeleteDetailsViewModel
    {
        public string Title { get; set; } = null!;

        [Display(Name ="Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string Article { get; set; } = null!;
    }
}
