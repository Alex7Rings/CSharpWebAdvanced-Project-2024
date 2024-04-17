namespace MoonGameRev.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Web.Infrastructure.Extensions;
    using MoonGameRev.Web.ViewModels.Journalist;
    using static MoonGameRev.Common.NotificationMessagesConstants;



    [Authorize]
    public class JournalistController : Controller
    {
        private readonly IJournalistService journalistService;

        public JournalistController(IJournalistService journalistService)
        {
            this.journalistService = journalistService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isJournalist = await this.journalistService.JournalistExistsByUserIdAsync(userId);

            if (isJournalist || User.IsInRole("Admin") || User.IsInRole("Moderator"))
            {
                this.TempData[ErrorMessage] = "You are already a journalist!";

                return this.RedirectToAction("All", "News");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeJournalistFormModel model)
        {
            string? userId = this.User.GetId();
            bool isJournalist = await this.journalistService.JournalistExistsByUserIdAsync(userId);

            if (isJournalist || User.IsInRole("Admin") || User.IsInRole("Moderator"))
            {
                this.TempData[ErrorMessage] = "You are already a journalist!";

                return this.RedirectToAction("All", "News");
            }

            bool isPhoneNumberTaken = await this.journalistService.JournalistExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "A journalist with the provided phone number already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            try
            {
                await this.journalistService.CreateAsync(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while registering you as an journalist! Please try again later or contact administrator.";
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("All", "News");
        }
    }
}
