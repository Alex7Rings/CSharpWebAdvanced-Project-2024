using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Review;

namespace MoonGameRev.Services.Data
{
    public class ReviewService : IReviewService
    {
        private readonly MoonGameRevDbContext dbContext;

        public ReviewService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddReviewAsync(ReviewFormModel reviewModel, string userId, int gameId)
        {
            Review newReview = new Review
            {
                Rating = reviewModel.Rating,
                Pros = reviewModel.Pros,
                Cons = reviewModel.Cons,
                Comment = reviewModel.Comment,
                UserId = userId, // Set the user ID
                GameID = gameId // Set the game ID
            };

            await dbContext.Reviews.AddAsync(newReview);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> HasReviewedGameAsync(string userId, int gameId)
        {
            return await dbContext.Reviews.AnyAsync(r => r.UserId == userId && r.GameID == gameId);
        }
    }
}
