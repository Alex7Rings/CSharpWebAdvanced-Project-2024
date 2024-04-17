namespace MoonGameRev.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    public class NewsAllViewModel
    {
        public string Id { get; set; } = null!;

        public string JournalistId { get; set; } = null!;

        public string Title { get; set; } = null!;

        [Display(Name ="Image Link")]
        public string PictureUrl { get; set; } = null!;

        public string Date { get; set; } = null!;
    }
}
