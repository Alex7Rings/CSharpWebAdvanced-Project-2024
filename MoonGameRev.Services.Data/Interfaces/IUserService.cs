namespace MoonGameRev.Services.Data.Interfaces
{
    using MoonGameRev.Web.Areas.Admin.ViewModels.User;

    public interface IUserService
    {
        Task<string> GetUserNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> AllAsync();
    }
}
