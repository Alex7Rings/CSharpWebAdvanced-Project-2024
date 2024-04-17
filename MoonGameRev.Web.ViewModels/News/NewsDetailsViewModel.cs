namespace MoonGameRev.Web.ViewModels.News
{
    using MoonGameRev.Web.ViewModels.Home;

    public class NewsDetailsViewModel: NewsAllViewModel
    {
        public string AuthorName { get; set; } = null!;

        public string Article { get; set; } = null!;

        public IEnumerable<IndexViewModel> LatestNews { get; set; }
    }
}
