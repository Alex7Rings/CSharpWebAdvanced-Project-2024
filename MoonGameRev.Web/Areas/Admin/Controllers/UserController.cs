using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.Areas.Admin.ViewModels.User;
using static MoonGameRev.Common.GeneralApplicationConstants;

namespace MoonGameRev.Web.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;
		private readonly IMemoryCache memoryCache;
		private readonly UserManager<AppUser> userManager;


        public UserController(IUserService userService, UserManager<AppUser> userManager, IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [HttpGet("/Admin/User/All")]
		[ResponseCache(Duration = 30)]//browser cache
		public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModel = this.memoryCache.Get<IEnumerable<UserViewModel>>(UserCacheKey);

			if (viewModel == null)
			{
				viewModel = await this.userService.AllAsync();

				MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

				foreach (var user in viewModel)
				{
					var appUser = await this.userManager.FindByIdAsync(user.Id);
					if (appUser != null)
					{
						user.IsAdmin = await this.userManager.IsInRoleAsync(appUser, "Admin");
						user.IsModerator = await this.userManager.IsInRoleAsync(appUser, "Moderator");
					}
				}

				this.memoryCache.Set(UserCacheKey, viewModel, memoryCacheEntryOptions);
			}


			return View(viewModel);
        }
    }
}
