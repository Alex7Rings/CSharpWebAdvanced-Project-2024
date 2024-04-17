namespace MoonGameRev.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using MoonGameRev.Data.Models;
    using MoonGameRev.Web.ViewModels.User;
    using static MoonGameRev.Common.GeneralApplicationConstants;
    using static MoonGameRev.Common.NotificationMessagesConstants;


    public class UserController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IUserStore<AppUser> userStore;
		private readonly IMemoryCache memoryCache;

		public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IUserStore<AppUser> userStore, IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userStore = userStore;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View(model);
			}

			AppUser user = new AppUser
			{
				UserName = model.UserName,
				Email = model.Email
			};

			IdentityResult result = await this.userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				await this.signInManager.SignInAsync(user, isPersistent: false);
				this.memoryCache.Remove(UserCacheKey);
				return this.RedirectToAction("Index", "Home");
			}
			else
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
				return this.View(model);
			}
		}



		[HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.EmailOrUserName);
            if (user == null)
            {
                user = await userManager.FindByNameAsync(model.EmailOrUserName);
            }

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email/username or password.");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                TempData[ErrorMessage] = "Invalid email/username or password.";
                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");

        }

    }
}
