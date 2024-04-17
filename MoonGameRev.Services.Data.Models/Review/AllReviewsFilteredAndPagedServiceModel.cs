namespace MoonGameRev.Services.Data.Models.Review
{
    using MoonGameRev.Web.ViewModels.Review;

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
