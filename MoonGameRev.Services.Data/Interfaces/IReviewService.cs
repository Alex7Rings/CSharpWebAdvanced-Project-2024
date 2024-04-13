using MoonGameRev.Services.Data.Models.Ranking;
using MoonGameRev.Services.Data.Models.Review;
using MoonGameRev.Web.ViewModels.Review;
using static MoonGameRev.Services.Data.Models.Ranking.RankingServiceModel;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface IReviewService
    {
        Task<bool> HasReviewedGameAsync(string userId, string gameId);

        Task AddReviewAsync(ReviewFormModel reviewModel, string userId, string gameId);

        Task<AllReviewsFilteredAndPagedServiceModel> AllAsync(string gameId, AllReviewsQueryModel queryModel);

        Task<IEnumerable<ReviewAllViewModel>> AllByUserIdAsync(string userId);

        Task<bool> ExistsReviewByIdAsync(string reviewId);

        Task<ReviewFormModel> GetReviewForEditByIdAsync(string reviewId);

        Task<bool> IsUserWhitIdCreatorOfReviewWhitIdAsync(string reviewId,  string userId);

        Task EditReviewByIdAndFormModelAsync(string reviewId, ReviewFormModel formModel);

        Task<ReviewPreDeleteDetailsViewModel> GetReviewForDeleteByIdAsync(string reviewId);

        Task DeleteReviewByIdAsync(string reviewId);

        Task<IEnumerable<RankingServiceModel>> GetRankingAsync();

        Task<IEnumerable<RankingServiceModel>> GetTopUsersAsync(int count);

    }
}
