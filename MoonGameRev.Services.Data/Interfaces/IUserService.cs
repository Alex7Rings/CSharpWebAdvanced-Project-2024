using MoonGameRev.Web.Areas.Admin.ViewModels.User;


namespace MoonGameRev.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
