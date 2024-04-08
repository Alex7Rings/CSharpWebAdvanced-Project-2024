using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.Infrastructure.Extensions;
using MoonGameRev.Web.ViewModels.News;
using static MoonGameRev.Common.NotificationMessagesConstants;

namespace MoonGameRev.Web.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly IJournalistService journalistService;
        private readonly INewsService newsService;

        public NewsController(IJournalistService journalistService, INewsService newsService)
        {
            this.journalistService = journalistService;
            this.newsService = newsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isJournalist = await this.journalistService.JournalistExistsByUserIdAsync(this.User.GetId()!);//Sure we have a user.
            if (!isJournalist)
            {
                this.TempData[ErrorMessage] = "Only journalists can add news!";

                return this.RedirectToAction("All", "News");
            }

            NewsFormModel model = new NewsFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewsFormModel model)
        {
            bool isJournalist = await this.journalistService.JournalistExistsByUserIdAsync(this.User.GetId()!);//Sure we have a user.
            if (!isJournalist)
            {
                this.TempData[ErrorMessage] = "Only journalists can add news!";

                return this.RedirectToAction("All", "News");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                string? journalistId = await this.journalistService.GetJournalistIdByUserIdAsync(this.User.GetId()!);
                await this.newsService.CreateAsync(model, journalistId!);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred while trying to add your news! Please try again later or contact administrator.";

                return this.View(model);
            }

            return this.RedirectToAction("All", "News");
        }
    }
}
