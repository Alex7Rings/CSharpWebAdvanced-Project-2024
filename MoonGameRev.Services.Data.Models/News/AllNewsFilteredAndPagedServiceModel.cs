using MoonGameRev.Web.ViewModels.News;

namespace MoonGameRev.Services.Data.Models.News
{
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
