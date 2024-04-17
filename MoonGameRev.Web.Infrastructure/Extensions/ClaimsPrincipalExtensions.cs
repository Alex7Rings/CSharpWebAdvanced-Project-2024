namespace MoonGameRev.Web.Infrastructure.Extensions
{
    using System.Security.Claims;
    using static MoonGameRev.Common.GeneralApplicationConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdminOrModerator(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName) || user.IsInRole(ModeratorRoleName);
        }
    }
}
