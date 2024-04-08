using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MoonGameRev.Web.Controllers
{
    [Authorize]
    public class JournalistController : Controller
    {
        public async Task<IActionResult> Become()
        {
            return View();
        }
    }
}
