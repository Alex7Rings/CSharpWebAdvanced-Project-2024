using MoonGameRev.Web.ViewModels.Review;

namespace MoonGameRev.Services.Data.Models.Review
{
    public class AllReviewsFilteredAndPagedServiceModel
    {
        public AllReviewsFilteredAndPagedServiceModel()
        {
            this.Reviews = new HashSet<ReviewAllViewModel>();
        }

        public int TotalReviewsCount { get; set; }

        public IEnumerable<ReviewAllViewModel> Reviews { get; set; }
    }
}
