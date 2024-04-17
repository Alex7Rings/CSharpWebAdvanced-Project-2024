namespace MoonGameRev.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MoonGameRev.Data.Models;
    using MoonGameRev.Web.ViewModels.User;
    using static MoonGameRev.Common.GeneralApplicationConstants;
    using static MoonGameRev.Common.NotificationMessagesConstants;



    public class HomeController : AdminController
    {
		private readonly UserManager<AppUser> userManager;

		public HomeController(UserManager<AppUser> userManager)
		{
			this.userManager = userManager;
		}

		public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult AddToModerator()
		{
			var model = new AddToModeratorViewModel();
			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddToModerator(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				TempData[ErrorMessage] = "Please enter a User ID.";
				return View(new AddToModeratorViewModel());
			}

			if (!Guid.TryParse(userId, out _))
			{
				TempData[ErrorMessage] = "Invalid User ID format.";
				return View(new AddToModeratorViewModel());
			}

			var user = await userManager.FindByIdAsync(userId);
			if (user == null)
			{
				TempData[ErrorMessage] = "User not found.";
				return View(new AddToModeratorViewModel());
			}

			if (await userManager.IsInRoleAsync(user, ModeratorRoleName))
			{
				TempData[ErrorMessage] = "User is already a moderator.";
				return View(new AddToModeratorViewModel());
			}

			await userManager.AddToRoleAsync(user, ModeratorRoleName);

			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveFromModerator(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				TempData[ErrorMessage] = "Please enter a User ID.";
				return RedirectToAction("AddToModerator");
			}

			if (!Guid.TryParse(userId, out _))
			{
				TempData[ErrorMessage] = "Invalid User ID format.";
				return RedirectToAction("AddToModerator");
			}

			var user = await userManager.FindByIdAsync(userId);
			if (user == null)
			{
				TempData[ErrorMessage] = "User not found.";
				return RedirectToAction("AddToModerator");
			}

			if (!await userManager.IsInRoleAsync(user, ModeratorRoleName))
			{
				TempData[ErrorMessage] = "User is not a moderator.";
				return RedirectToAction("AddToModerator");
			}

			await userManager.RemoveFromRoleAsync(user, ModeratorRoleName);

			TempData[SuccessMessage] = "User successfully removed from moderator role.";
			return RedirectToAction("Index");
		}
	}
}
