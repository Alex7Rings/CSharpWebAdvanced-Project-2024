using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data.Models.Review;
using MoonGameRev.Web.ViewModels.Review;
using MoonGameRev.Web.ViewModels.Review.Enums;

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

        public async Task<AllReviewsFilteredAndPagedServiceModel> AllAsync(int gameId, AllReviewsQueryModel queryModel)
        {
            IQueryable<Review> reviewsQuery = this.dbContext
                .Reviews
                .Where(r => r.GameID == gameId)
                .AsQueryable();

            reviewsQuery = queryModel.ReviewSorting switch
            {
                ReviewSorting.Newest => reviewsQuery.OrderByDescending(r => r.ReviewDate),
                ReviewSorting.RatingHighToLow => reviewsQuery.OrderByDescending(r => r.Rating),
                ReviewSorting.RatingLowToHigh => reviewsQuery.OrderBy(r => r.Rating),
                _ => reviewsQuery.OrderByDescending(r => r.ReviewDate)
            };

            IEnumerable<ReviewAllViewModel> allReviews = await reviewsQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.ReviewsPerPage)
                .Take(queryModel.ReviewsPerPage)
                .Select(r => new ReviewAllViewModel
                {
                    Id = r.Id.ToString(),
                    UserName = r.User.ToString(),
                    Pros = r.Pros,
                    Cons = r.Cons,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    Date = r.ReviewDate.ToString()
                })
                .ToArrayAsync();

            int totalReviews = reviewsQuery.Count();

            return new AllReviewsFilteredAndPagedServiceModel()
            {
                TotalReviewsCount = totalReviews,
                Reviews = allReviews
            };
        }

        public async Task<IEnumerable<ReviewAllViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<ReviewAllViewModel> allUserReviews = await this.dbContext
                 .Reviews
                 .Where(r => r.UserId == userId)
                 .Select(r => new ReviewAllViewModel
                 {
                     Id= r.Id.ToString(),
                     UserName = r.User.ToString(),
                     Pros = r.Pros,
                     Cons = r.Cons,
                     Comment = r.Comment,
                     Rating = r.Rating,
                     Date = r.ReviewDate.ToString(),
                     GameName = r.Game.Title,
                     CoverImage = r.Game.CoverImage,
                     GameId = r.GameID
                 })
                 .ToArrayAsync();

            return allUserReviews;
        }

        public async Task<bool> HasReviewedGameAsync(string userId, int gameId)
        {
            return await dbContext.Reviews.AnyAsync(r => r.UserId == userId && r.GameID == gameId);
        }
    }
}
