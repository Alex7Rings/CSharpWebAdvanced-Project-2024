using MoonGameRev.Services.Data.Models.Review;
using MoonGameRev.Web.ViewModels.Review;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface IReviewService
    {
        Task<bool> HasReviewedGameAsync(string userId, int gameId);

        Task AddReviewAsync(ReviewFormModel reviewModel, string userId, int gameId);

        Task<AllReviewsFilteredAndPagedServiceModel> AllAsync(int gameId, AllReviewsQueryModel queryModel);

        Task<IEnumerable<ReviewAllViewModel>> AllByUserIdAsync(string userId);

        Task<bool> ExistsReviewByIdAsync(string reviewId);

        Task<ReviewFormModel> GetReviewForEditByIdAsync(string reviewId);

        Task<bool> IsUserWhitIdCreatorOfReviewWhitIdAsync(string reviewId,  string userId);

        Task EditReviewByIdAndFormModelAsync(string reviewId, ReviewFormModel formModel);

        Task<ReviewPreDeleteDetailsViewModel> GetReviewForDeleteByIdAsync(string reviewId);

        Task DeleteReviewByIdAsync(string reviewId);

    }
}
