using MoonGameRev.Web.ViewModels.Journalist;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface IJournalistService
    {
        Task<bool> JournalistExistsByUserIdAsync(string userId);

        Task<bool> JournalistExistsByPhoneNumberAsync(string phoneNumber);

        Task CreateAsync(string userId, BecomeJournalistFormModel model);

        Task<string?> GetJournalistIdByUserIdAsync(string userId);
    }
}
