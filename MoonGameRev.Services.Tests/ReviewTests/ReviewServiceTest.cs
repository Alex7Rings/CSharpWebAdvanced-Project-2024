namespace MoonGameRev.Services.Tests.ReviewTests
{
	using Microsoft.EntityFrameworkCore;
	using MoonGameRev.Data;
	using MoonGameRev.Services.Data;
	using MoonGameRev.Services.Data.Interfaces;
	using MoonGameRev.Web.ViewModels.Review;
	using MoonGameRev.Web.ViewModels.Review.Enums;
	using static MoonGameRev.Services.Tests.ReviewTests.ReviewDatabaseSeeder;

	public class ReviewServiceTest
	{
		private MoonGameRevDbContext dbContext;
		private DbContextOptions<MoonGameRevDbContext> optionsDb;

		private IReviewService reviewService;

		[SetUp]
		public void Setup()
		{
			optionsDb = new DbContextOptionsBuilder<MoonGameRevDbContext>()
			   .UseInMemoryDatabase("MoonGameRevInMemory" + Guid.NewGuid().ToString()).Options;

			dbContext = new MoonGameRevDbContext(optionsDb);

			dbContext.Database.EnsureCreated();

			ReviewSeedDatabase(dbContext);

			reviewService = new ReviewService(dbContext);
		}


		[Test]
		public async Task AddReviewAsync_ValidReview_ShouldAddReviewToDatabase()
		{
			var reviewModel = new ReviewFormModel
			{
				Rating = 8, 
				Pros = "Test pros",
				Cons = "Test cons",
				Comment = "Test comment"
			};

			string userId = ReviewDatabaseSeeder.User1.Id.ToString();
			string gameId = ReviewDatabaseSeeder.Game1.Id.ToString();

			await reviewService.AddReviewAsync(reviewModel, userId, gameId);

			var addedReview = await dbContext.Reviews.FirstOrDefaultAsync(r => r.Rating == reviewModel.Rating &&
																			  r.Pros == reviewModel.Pros &&
																			  r.Cons == reviewModel.Cons &&
																			  r.Comment == reviewModel.Comment &&
																			  r.UserId.ToString() == userId &&
																			  r.GameID.ToString() == gameId);
			Assert.NotNull(addedReview);
			Assert.AreEqual(reviewModel.Rating, addedReview.Rating);
			Assert.AreEqual(reviewModel.Pros, addedReview.Pros);
			Assert.AreEqual(reviewModel.Cons, addedReview.Cons);
			Assert.AreEqual(reviewModel.Comment, addedReview.Comment);
			Assert.AreEqual(userId, addedReview.UserId.ToString());
			Assert.AreEqual(gameId, addedReview.GameID.ToString());
		}

		[Test]
		public async Task AllAsync_ReturnsFilteredAndPagedReviews()
		{
			var gameId = ReviewDatabaseSeeder.Game1.Id.ToString();
			var queryModel = new AllReviewsQueryModel
			{
				CurrentPage = 1,
				ReviewsPerPage = 5,
				ReviewSorting = ReviewSorting.RatingHighToLow 
			};

			var result = await reviewService.AllAsync(gameId, queryModel);

			Assert.NotNull(result);
			Assert.NotNull(result.Reviews);

			// Check if the reviews are sorted correctly based on the selected sorting option
			if (queryModel.ReviewSorting == ReviewSorting.RatingHighToLow)
			{
				Assert.IsTrue(result.Reviews.Select(r => r.Rating).SequenceEqual(result.Reviews.OrderByDescending(r => r.Rating).Select(r => r.Rating)));
			}
			else if (queryModel.ReviewSorting == ReviewSorting.RatingLowToHigh)
			{
				Assert.IsTrue(result.Reviews.Select(r => r.Rating).SequenceEqual(result.Reviews.OrderBy(r => r.Rating).Select(r => r.Rating)));
			}
			else
			{
				// If the default sorting option is applied, check if the reviews are sorted by date in descending order
				Assert.IsTrue(result.Reviews.Select(r => r.Date).SequenceEqual(result.Reviews.OrderByDescending(r => DateTime.Parse(r.Date)).Select(r => r.Date)));
			}

			// Check if the total number of reviews matches the expected count based on the database
			var expectedTotalReviews = ReviewDatabaseSeeder.Review1.GameID == Guid.Parse(gameId) ? 1 : 0;
			Assert.AreEqual(expectedTotalReviews, result.TotalReviewsCount);
		}

		[Test]
		public async Task AllByUserIdAsync_ReturnsUserReviews()
		{
			var userId = ReviewDatabaseSeeder.User1.Id.ToString();

			var result = await reviewService.AllByUserIdAsync(userId);

			Assert.NotNull(result);

			Assert.IsTrue(result.All(r => r.UserName == ReviewDatabaseSeeder.User1.UserName));

			foreach (var review in result)
			{
				var expectedReview = dbContext.Reviews.FirstOrDefault(r => r.Id == Guid.Parse(review.Id));
				Assert.NotNull(expectedReview);
				Assert.AreEqual(expectedReview.Pros, review.Pros);
				Assert.AreEqual(expectedReview.Cons, review.Cons);
				Assert.AreEqual(expectedReview.Comment, review.Comment);
				Assert.AreEqual(expectedReview.Rating, review.Rating);
				Assert.AreEqual(expectedReview.ReviewDate.ToString(), review.Date);
				Assert.AreEqual(expectedReview.Game.Title, review.GameName);
				Assert.AreEqual(expectedReview.Game.CoverImage, review.CoverImage);
				Assert.AreEqual(expectedReview.GameID.ToString(), review.GameId);
			}
		}

		[Test]
		public async Task DeleteReviewByIdAsync_DeletesReview()
		{
			var reviewIdToDelete = ReviewDatabaseSeeder.Review1.Id.ToString();

			await reviewService.DeleteReviewByIdAsync(reviewIdToDelete);

			// Check if the review is deleted from the database
			var deletedReview = await dbContext.Reviews.FindAsync(Guid.Parse(reviewIdToDelete));
			Assert.Null(deletedReview);

		}

		[Test]
		public async Task EditReviewByIdAndFormModelAsync_EditsReview()
		{
			var reviewIdToEdit = ReviewDatabaseSeeder.Review1.Id.ToString();
			var newRating = 4.0; 
			var newPros = "Updated pros"; 
			var newCons = "Updated cons"; 
			var newComment = "Updated comment"; 

			var formModel = new ReviewFormModel
			{
				Rating = newRating,
				Pros = newPros,
				Cons = newCons,
				Comment = newComment
			};

			await reviewService.EditReviewByIdAndFormModelAsync(reviewIdToEdit, formModel);

			var editedReview = await dbContext.Reviews.FindAsync(Guid.Parse(reviewIdToEdit));
			Assert.NotNull(editedReview);

			Assert.AreEqual(formModel.Rating, editedReview.Rating);
			Assert.AreEqual(formModel.Pros, editedReview.Pros);
			Assert.AreEqual(formModel.Cons, editedReview.Cons);
			Assert.AreEqual(formModel.Comment, editedReview.Comment);
		}

		[Test]
		public async Task ExistsReviewByIdAsync_ReviewExists_ReturnsTrue()
		{
			var existingReviewId = ReviewDatabaseSeeder.Review1.Id.ToString(); 

			var result = await reviewService.ExistsReviewByIdAsync(existingReviewId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task ExistsReviewByIdAsync_ReviewDoesNotExist_ReturnsFalse()
		{
			var nonExistingReviewId = Guid.NewGuid().ToString(); 

			var result = await reviewService.ExistsReviewByIdAsync(nonExistingReviewId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetReviewForDeleteByIdAsync_ReturnsCorrectReviewDetails()
		{
			var reviewId = Review1.Id.ToString(); 

			var result = await reviewService.GetReviewForDeleteByIdAsync(reviewId);

			Assert.IsNotNull(result);
			Assert.AreEqual(Review1.Rating, result.Rating);
			Assert.AreEqual(Review1.Pros, result.Pros);
			Assert.AreEqual(Review1.Cons, result.Cons);
			Assert.AreEqual(Review1.Comment, result.Comment);
		}

		[Test]
		public async Task GetReviewForEditByIdAsync_ReturnsCorrectReviewDetails()
		{
			var reviewId = Review1.Id.ToString(); 

			var result = await reviewService.GetReviewForEditByIdAsync(reviewId);

			Assert.IsNotNull(result);
			Assert.AreEqual(Review1.Rating, result.Rating);
			Assert.AreEqual(Review1.Pros, result.Pros);
			Assert.AreEqual(Review1.Cons, result.Cons);
			Assert.AreEqual(Review1.Comment, result.Comment);
		}

		[Test]
		public async Task HasReviewedGameAsync_ReturnsTrueIfUserHasReviewedGame()
		{
			var userId = User1.Id.ToString(); 
			var gameId = Game1.Id.ToString(); 

			var result = await reviewService.HasReviewedGameAsync(userId, gameId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task HasReviewedGameAsync_ReturnsFalseIfUserHasNotReviewedGame()
		{
			var userId = User2.Id.ToString(); 
			var gameId = Game2.Id.ToString(); 

			var result = await reviewService.HasReviewedGameAsync(userId, gameId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task IsUserWithIdCreatorOfReviewWithIdAsync_ReturnsTrueIfUserIsCreator()
		{
			var reviewId = Review1.Id.ToString(); 
			var userId = User1.Id.ToString(); 

			var result = await reviewService.IsUserWhitIdCreatorOfReviewWhitIdAsync(reviewId, userId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task IsUserWithIdCreatorOfReviewWithIdAsync_ReturnsFalseIfUserIsNotCreator()
		{
			var reviewId = Review2.Id.ToString(); 
			var userId = User2.Id.ToString(); 

			var result = await reviewService.IsUserWhitIdCreatorOfReviewWhitIdAsync(reviewId, userId);

			Assert.IsFalse(result);
		}

	}
}
