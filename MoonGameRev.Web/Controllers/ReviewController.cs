using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Review;
using System.Security.Claims;

namespace MoonGameRev.Web.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly UserManager<IdentityUser> userManager;

        public ReviewController(IReviewService reviewService, UserManager<IdentityUser> userManager)
        {
            this.reviewService = reviewService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int gameId)
        {
            // Get the current user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check if the user has already reviewed the game
            bool hasReviewed = await reviewService.HasReviewedGameAsync(userId, gameId);

            // If the user has already reviewed the game, redirect with an error message
            if (hasReviewed)
            {
                TempData["ErrorMessage"] = "You have already submitted a review for this game.";
                return RedirectToAction("Mine", "Review"); // Redirect to the game details page
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewFormModel reviewModel, int gameId)
        {
            if (!ModelState.IsValid)
            {
                // Handle invalid model state
                return View(reviewModel);
            }

            // Get the current user's ID
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                // User is not authenticated, handle accordingly (e.g., redirect to login page)
                return RedirectToAction("Login", "Account");
            }

            // Add the review to the database
            await reviewService.AddReviewAsync(reviewModel, user.Id, gameId);

            // Redirect back to the game details page with the same gameId
            return RedirectToAction("Details", "Game", new { gameId = gameId });
        }

        [AllowAnonymous]
        public async Task<IActionResult> RatingInformation()
        {
            return View();
        }
    }
}
