namespace MoonGameRev.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Web.ViewModels.Home;
    using static MoonGameRev.Common.GeneralApplicationConstants;

    public class HomeController : Controller
    {
        private readonly IGameService gameService;
        private readonly INewsService newsService;

        public HomeController(IGameService gameService, INewsService newsService)
        {
           this.gameService = gameService;
           this.newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            
            IEnumerable<IndexViewModel> upcomingGamesViewModel =
               await this.gameService.LastFiveUpcomingGamesAsync();

           
            IEnumerable<IndexViewModel> trendingGamesViewModel =
               await this.gameService.LastFiveGamesAsync();

            IEnumerable<IndexViewModel> latestNews =
                await this.newsService.LatestNewsAsync();

            
            ViewData["UpcomingGames"] = upcomingGamesViewModel;
            ViewData["TrendingGames"] = trendingGamesViewModel;
            ViewData["LatestNews"] = latestNews;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            if (statusCode == 401)
            {
                return this.View("Error401");
            }

            return this.View();
        }
    }
}
