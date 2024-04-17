namespace MoonGameRev.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MoonGameRev.Data.Models;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Services.Data.Models.Review;
    using MoonGameRev.Web.Infrastructure.Extensions;
    using MoonGameRev.Web.ViewModels.Review;
    using System.Security.Claims;
    using static MoonGameRev.Common.NotificationMessagesConstants;


    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly UserManager<AppUser> userManager;

        public ReviewController(IReviewService reviewService, UserManager<AppUser> userManager)
        {
            this.reviewService = reviewService;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(Guid gameId, [FromQuery]AllReviewsQueryModel queryModel)
        {
            AllReviewsFilteredAndPagedServiceModel serviceModel =
                await this.reviewService.AllAsync(gameId.ToString(), queryModel);

            queryModel.Reviews = serviceModel.Reviews;
            queryModel.TotalReviews = serviceModel.TotalReviewsCount;

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add(string gameId)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool hasReviewed = await reviewService.HasReviewedGameAsync(userId, gameId);

            if (hasReviewed)
            {
                TempData["ErrorMessage"] = "You have already submitted a review for this game.";
                return RedirectToAction("Mine", "Review"); // Redirect to the game details page
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewFormModel reviewModel, string gameId)
        {
            if (!ModelState.IsValid)
            {
                return View(reviewModel);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            await reviewService.AddReviewAsync(reviewModel, user.Id.ToString(), gameId);

            this.TempData[SuccessMessage] = "The review was added successfully";
            return RedirectToAction("Details", "Game", new { id = gameId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool reviewExists = await this.reviewService
                .ExistsReviewByIdAsync(id);

            if (!reviewExists)
            {
                this.TempData[ErrorMessage] = "Review with the provided id does not exists!";

                return this.RedirectToAction("Mine", "Review");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isUserCreatorOfTheReview = await this.reviewService
                .IsUserWhitIdCreatorOfReviewWhitIdAsync(id, userId);

            if (!isUserCreatorOfTheReview)
            {
                this.TempData[ErrorMessage] = "You must be the creator to edit this review!";
                return RedirectToAction("Mine", "Review");
            }

            try
            {
				ReviewFormModel formModel = await this.reviewService
	                     .GetReviewForEditByIdAsync(id);


				return this.View(formModel);
			}
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";

                return this.RedirectToAction("Mine", "Review");
			}
        }

        [HttpPost]
		public async Task<IActionResult> Edit(string id, ReviewFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

			bool reviewExists = await this.reviewService
				.ExistsReviewByIdAsync(id);

			if (!reviewExists)
			{
				this.TempData[ErrorMessage] = "Review with the provided id does not exists!";

				return this.RedirectToAction("Mine", "Review");
			}

			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			bool isUserCreatorOfTheReview = await this.reviewService
				.IsUserWhitIdCreatorOfReviewWhitIdAsync(id, userId);

			if (!isUserCreatorOfTheReview)
			{
				this.TempData[ErrorMessage] = "You must be the creator to edit this review!";
				return RedirectToAction("Mine", "Review");
			}

            try
            {
                await this.reviewService.EditReviewByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to update the review. Please try again later or contact administrator!");

                return this.View(model);
            }

            this.TempData[SuccessMessage] = "The review was edited successfully";
            return this.RedirectToAction("Mine", "Review");

		}

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool reviewExists = await this.reviewService.ExistsReviewByIdAsync(id);

            if (!reviewExists)
            {
                this.TempData[ErrorMessage] = "Review with the provided id does not exist!";
                return RedirectToAction("Mine", "Review");
            }

            string userId = User.GetId();

            bool isUserCreatorOfTheReview = await this.reviewService.IsUserWhitIdCreatorOfReviewWhitIdAsync(id, userId);
            bool isAdminOrModerator = User.IsAdminOrModerator();


            if (!isUserCreatorOfTheReview && !isAdminOrModerator)
            {
                this.TempData[ErrorMessage] = "You must be the creator or have admin/moderator privileges to delete this review!";
                return RedirectToAction("Mine", "Review");
            }

            try
            {
                ReviewPreDeleteDetailsViewModel viewModel = await this.reviewService.GetReviewForDeleteByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";
                return RedirectToAction("Mine", "Review");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ReviewPreDeleteDetailsViewModel model)
        {
            bool reviewExists = await this.reviewService.ExistsReviewByIdAsync(id);

            if (!reviewExists)
            {
                this.TempData[ErrorMessage] = "Review with the provided id does not exist!";
                return this.RedirectToAction("Mine", "Review");
            }

            string userId = User.GetId();

            bool isUserCreatorOfTheReview = await this.reviewService.IsUserWhitIdCreatorOfReviewWhitIdAsync(id, userId);
            bool isAdminOrModerator = User.IsAdminOrModerator();

            if (!isUserCreatorOfTheReview && !isAdminOrModerator)
            {
                this.TempData[ErrorMessage] = "You must be the creator or have admin/moderator privileges to delete this review!";
                return RedirectToAction("Mine", "Review");
            }

            try
            {
                await this.reviewService.DeleteReviewByIdAsync(id);
                this.TempData[WarningMessage] = "The review was deleted successfully";
                return RedirectToAction("Mine", "Review");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occurred while trying to delete the review. Please try again later or contact the administrator.";
                return RedirectToAction("Mine", "Review");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<ReviewAllViewModel> myReviews =
                new List<ReviewAllViewModel>();

            string userId = this.User.GetId()!;

            myReviews.AddRange(await this.reviewService.AllByUserIdAsync(userId));

            return View(myReviews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> RatingInformation()
        {
            return View();
        }
    }
}
