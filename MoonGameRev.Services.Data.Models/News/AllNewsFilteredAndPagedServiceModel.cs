namespace MoonGameRev.Services.Data.Models.News
{
    using MoonGameRev.Web.ViewModels.News;

    public class AllNewsFilteredAndPagedServiceModel
    {
        public AllNewsFilteredAndPagedServiceModel()
        {
            this.News = new HashSet<NewsAllViewModel>();
        }

        public int TotalNewsCount {  get; set; }

        public IEnumerable<NewsAllViewModel> News { get; set; }
    }
}
