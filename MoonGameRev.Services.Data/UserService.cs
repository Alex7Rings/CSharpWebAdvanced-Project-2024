namespace MoonGameRev.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using MoonGameRev.Data;
    using MoonGameRev.Data.Models;
    using MoonGameRev.Services.Data.Interfaces;
    using MoonGameRev.Web.Areas.Admin.ViewModels.User;


    public class UserService : IUserService
    {
        private readonly MoonGameRevDbContext dbContext;


        public UserService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    UserName = u.UserName
                })
                .ToListAsync();

            foreach (UserViewModel user in allUsers)
            {
                Journalist? journalist = await this.dbContext
                    .Journalists
                    .FirstOrDefaultAsync(j => j.UserId.ToString() == user.Id);

                if (journalist != null)
                {
                    user.PhoneNumber = journalist.PhoneNumber;
                }
                else
                {
                    user.PhoneNumber = string.Empty;
                }
            }

            var orderedUsers = allUsers
                .OrderByDescending(u => u.IsAdmin)
                .ThenByDescending(u => u.IsModerator)
                .ThenBy(u => u.UserName);

            return orderedUsers;
        }

        public async Task<string> GetUserNameByIdAsync(string userId)
        {
            AppUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId); 

            if (user == null)
            {
                return string.Empty;
            }

            return user.UserName;
        }
    }
}
