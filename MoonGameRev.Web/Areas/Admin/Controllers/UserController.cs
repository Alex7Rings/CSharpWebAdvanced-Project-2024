using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.Areas.Admin.ViewModels.User;

namespace MoonGameRev.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;
        private readonly UserManager<AppUser> userManager;

        public UserController(IUserService userService, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        [HttpGet("/Admin/User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = await this.userService.AllAsync();

            foreach (var user in viewModel)
            {
                var appUser = await this.userManager.FindByIdAsync(user.Id);
                if (appUser != null)
                {
                    user.IsAdmin = await this.userManager.IsInRoleAsync(appUser, "Admin");
                    user.IsModerator = await this.userManager.IsInRoleAsync(appUser, "Moderator");
                }
            }

            return View(viewModel);
        }
    }
}
