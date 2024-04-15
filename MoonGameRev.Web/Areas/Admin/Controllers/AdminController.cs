using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MoonGameRev.Common.GeneralApplicationConstants;

namespace MoonGameRev.Web.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
       
    }
}
