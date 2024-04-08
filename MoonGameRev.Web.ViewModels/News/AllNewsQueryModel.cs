using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.GeneralApplicationConstants;

namespace MoonGameRev.Web.ViewModels.News
{
    public class AllNewsQueryModel
    {
        public AllNewsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.NewsPerPage = EntitiesPerPage;
            this.News = new HashSet<NewsAllViewModel>();
        }

        [Display(Name ="Search by word")]
        public string? SearchString { get; set; }

        public int CurrentPage {  get; set; }

        public int NewsPerPage { get; set; }

        public int TotalNews { get; set; }

        public IEnumerable<NewsAllViewModel> News { get; set; }
    }
}
