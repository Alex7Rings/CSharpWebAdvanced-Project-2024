using MoonGameRev.Services.Data.Models.Review;
using MoonGameRev.Web.ViewModels.Review;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface IReviewService
    {
        Task<bool> HasReviewedGameAsync(string userId, int gameId);

        Task AddReviewAsync(ReviewFormModel reviewModel, string userId, int gameId);

        Task<AllReviewsFilteredAndPagedServiceModel> AllAsync(int gameId, AllReviewsQueryModel queryModel);
    }
}
