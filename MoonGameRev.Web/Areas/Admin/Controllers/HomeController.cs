using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoonGameRev.Data.Models;
using MoonGameRev.Web.ViewModels.User;
using static MoonGameRev.Common.GeneralApplicationConstants;

namespace MoonGameRev.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
		private readonly SignInManager<AppUser> signInManager;
		private readonly UserManager<AppUser> userManager;

		public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			this.signInManager = signInManager;
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
			var user = await userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			await userManager.AddToRoleAsync(user, ModeratorRoleName);

			return RedirectToAction("Index", "Home");
		}
	}
}
