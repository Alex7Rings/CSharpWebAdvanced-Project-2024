using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Journalist;

namespace MoonGameRev.Services.Data
{
    public class JournalistService : IJournalistService
    {
        private readonly MoonGameRevDbContext dbContext;

        public JournalistService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(string userId, BecomeJournalistFormModel model)
        {
            Journalist journalist = new Journalist()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = userId,
            };

            await this.dbContext.Journalists.AddAsync(journalist);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> JournalistExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                            .Journalists
                            .AnyAsync(j => j.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> JournalistExistsByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
                .Journalists
                .AnyAsync(j=>j.UserId == userId);

            return result;
        }
    }
}
