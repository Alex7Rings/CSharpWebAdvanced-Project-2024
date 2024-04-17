namespace MoonGameRev.Services.Data.Interfaces
{
    using MoonGameRev.Web.ViewModels.Journalist;

    public interface IJournalistService
    {
        Task<bool> JournalistExistsByUserIdAsync(string userId);

        Task<bool> JournalistExistsByPhoneNumberAsync(string phoneNumber);

        Task CreateAsync(string userId, BecomeJournalistFormModel model);

        Task<string?> GetJournalistIdByUserIdAsync(string userId);
    }
}
