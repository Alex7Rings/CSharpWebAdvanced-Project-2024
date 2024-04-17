namespace MoonGameRev.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Services.Data.Models.News;
    using MoonGameRev.Web.Infrastructure.Extensions;
    using MoonGameRev.Web.ViewModels.Home;
    using MoonGameRev.Web.ViewModels.News;
    using static MoonGameRev.Common.NotificationMessagesConstants;


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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllNewsQueryModel queryModel)
        {
            AllNewsFilteredAndPagedServiceModel serviceModel =
                await this.newsService.AllAsync(queryModel);

            queryModel.News = serviceModel.News;
            queryModel.TotalNews = serviceModel.TotalNewsCount;

            return this.View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            
            bool isJournalist = await this.journalistService.JournalistExistsByUserIdAsync(this.User.GetId()!);
            if (!isJournalist && !this.User.IsAdminOrModerator())
            {
                this.TempData[ErrorMessage] = "Only journalists can add news!";
                return this.RedirectToAction("All", "News");
            }

            try
            {
                NewsFormModel model = new NewsFormModel();
                return View(model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occurred. Please try again later or contact the administrator.";
                return this.RedirectToAction("All", "News");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewsFormModel model)
        {
            
            bool isJournalist = await this.journalistService.JournalistExistsByUserIdAsync(this.User.GetId()!);
            if (!isJournalist && !this.User.IsAdminOrModerator())
            {
                this.TempData[ErrorMessage] = "Only journalists add news!";
                return this.RedirectToAction("All", "News");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                string? journalistId = await this.journalistService.GetJournalistIdByUserIdAsync(this.User.GetId()!);
                string newsId = await this.newsService.CreateAsync(model, journalistId!);
                this.TempData[SuccessMessage] = "The article was added successfully";
                return this.RedirectToAction("Details", "News", new { id = newsId });
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occurred while trying to add your news! Please try again later or contact the administrator.";
                return this.View(model);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> JournalistNews(string journalistId)
        {
            try
            {
				IEnumerable<NewsAllViewModel> journalistNews = await this.newsService.AllByJournalistIdAsync(journalistId);
				return View(journalistNews);
			}
            catch (Exception)
            {
				this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";
				return this.RedirectToAction("All", "News");
			}

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool newsExists = await this.newsService
                .ExistsByIdAsync(id);
            if (!newsExists)
            {
                this.TempData[ErrorMessage] = "Article whit the provided id does not exist!";

                return this.RedirectToAction("All", "News");
            }
            try
            {
                IEnumerable<IndexViewModel> latestNews =
                 await this.newsService.LatestNewsAsync();

                ViewData["LatestNews"] = latestNews;

                NewsDetailsViewModel? model = await this.newsService
	            .GetDetailsByIdAsync(id);

				return this.View(model);
			}
            catch (Exception)
            {
				this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";
				return this.RedirectToAction("All", "News");
			}

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool newsExists = await this.newsService.ExistsByIdAsync(id);
            if (!newsExists)
            {
                this.TempData[ErrorMessage] = "Article with the provided id does not exist!";
                return this.RedirectToAction("All", "News");
            }

            
            string? journalistId = await this.journalistService.GetJournalistIdByUserIdAsync(this.User.GetId()!);
            bool isJournalist = await this.newsService.IsJournalistWithIdOwnerOfTheNewsIdAsync(id, journalistId!);
            if (!isJournalist && !this.User.IsAdminOrModerator())
            {
                this.TempData[ErrorMessage] = "You must be the article owner or an admin/moderator to edit news!";
                return this.RedirectToAction("All", "News");
            }

            try
            {
                NewsFormModel model = await this.newsService.GetNewsForEditAsync(id);
                return this.View(model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occurred. Please try again later or contact the administrator.";
                return this.RedirectToAction("All", "News");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, NewsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            bool newsExists = await this.newsService.ExistsByIdAsync(id);
            if (!newsExists)
            {
                this.TempData[ErrorMessage] = "Article with the provided id does not exist!";
                return this.RedirectToAction("All", "News");
            }

            
            string? journalistId = await this.journalistService.GetJournalistIdByUserIdAsync(this.User.GetId()!);
            bool isJournalist = await this.newsService.IsJournalistWithIdOwnerOfTheNewsIdAsync(id, journalistId!);
            if (!isJournalist && !this.User.IsAdminOrModerator())
            {
                this.TempData[ErrorMessage] = "You must be the article owner or an admin/moderator to edit news!";
                return this.RedirectToAction("All", "News");
            }

            try
            {
                await this.newsService.EditNewsByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "An unexpected error occurred while trying to update the article. Please try again later or contact the administrator.");
                return this.View(model);
            }

            this.TempData[SuccessMessage] = "The article was edited successfully";
            return this.RedirectToAction("Details", "News", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool newsExists = await this.newsService.ExistsByIdAsync(id);
            if (!newsExists)
            {
                this.TempData[ErrorMessage] = "Article with the provided id does not exist!";
                return this.RedirectToAction("All", "News");
            }

           
            string? journalistId = await this.journalistService.GetJournalistIdByUserIdAsync(this.User.GetId()!);
            bool isJournalist = await this.newsService.IsJournalistWithIdOwnerOfTheNewsIdAsync(id, journalistId!);
            if (!isJournalist && !this.User.IsAdminOrModerator())
            {
                this.TempData[ErrorMessage] = "You must be the article owner or an admin/moderator to delete news!";
                return this.RedirectToAction("All", "News");
            }

            try
            {
                NewsPreDeleteDetailsViewModel viewModel = await this.newsService.GetNewsForDeleteByIdAsync(id);
                return this.View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occurred. Please try again later or contact the administrator.";
                return this.RedirectToAction("All", "News");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, NewsPreDeleteDetailsViewModel model)
        {
            bool newsExists = await this.newsService.ExistsByIdAsync(id);
            if (!newsExists)
            {
                this.TempData[ErrorMessage] = "Article with the provided id does not exist!";
                return this.RedirectToAction("All", "News");
            }

           
            string? journalistId = await this.journalistService.GetJournalistIdByUserIdAsync(this.User.GetId()!);
            bool isJournalist = await this.newsService.IsJournalistWithIdOwnerOfTheNewsIdAsync(id, journalistId!);
            if (!isJournalist && !this.User.IsAdminOrModerator())
            {
                this.TempData[ErrorMessage] = "You must be the article owner or an admin/moderator to delete news!";
                return this.RedirectToAction("All", "News");
            }

            try
            {
                await this.newsService.DeleteByIdAsync(id);
                this.TempData[WarningMessage] = "The article was deleted successfully";
                return this.RedirectToAction("All", "News");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "An unexpected error occurred while trying to delete the article. Please try again later or contact the administrator.";
                return this.RedirectToAction("All", "News");
            }
        }
    }
}
