using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoonGameRev.Web.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> RatingInformation()
        {
            return View();
        }
    }
}
