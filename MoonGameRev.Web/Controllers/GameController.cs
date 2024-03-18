using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoonGameRev.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Games()
        {
            return View();
        }
    }
}
