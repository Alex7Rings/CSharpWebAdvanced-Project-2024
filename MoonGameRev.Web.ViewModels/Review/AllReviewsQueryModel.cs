using MoonGameRev.Web.ViewModels.Review.Enums;
using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.GeneralApplicationConstants;

namespace MoonGameRev.Web.ViewModels.Review
{
    public class AllReviewsQueryModel
    {
        public AllReviewsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ReviewsPerPage = EntitiesPerPage;
            this.Reviews = new HashSet<ReviewAllViewModel>();
        }

        [Display(Name = "Sort Review By")]
        public ReviewSorting ReviewSorting { get; set; }

        public int CurrentPage { get; set; }

        public int ReviewsPerPage { get; set; }

        public int TotalReviews { get; set; }

        public int GameId { get; set; }  

        public IEnumerable<ReviewAllViewModel> Reviews { get; set; }
    }
}
