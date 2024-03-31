using MoonGameRev.Data;
using MoonGameRev.Services.Data.Interfaces;

namespace MoonGameRev.Services.Data
{
    public class ReviewService : IReviewService
    {
        private readonly MoonGameRevDbContext dbContext;

        public ReviewService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string GetRatingCategory(double averageRating)
        {
            if (averageRating >= 9.5)
            {
                return "Masterpiece";
            }
            else if (averageRating >= 9.0)
            {
                return "Outstanding";
            }
            else if (averageRating >= 8.0)
            {
                return "Great";
            }
            else if (averageRating >= 7.0)
            {
                return "Good";
            }
            else if (averageRating >= 6.0)
            {
                return "Decent";
            }
            else if (averageRating >= 5.0)
            {
                return "Average";
            }
            else if (averageRating >= 4.0)
            {
                return "Mediocre";
            }
            else if (averageRating >= 3.0)
            {
                return "Poor";
            }
            else if (averageRating >= 2.0)
            {
                return "Bad";
            }
            else
            {
                return "Awful";
            }
        }
    }
}
