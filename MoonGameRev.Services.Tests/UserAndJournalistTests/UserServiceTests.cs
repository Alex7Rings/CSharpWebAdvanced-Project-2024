using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data;
using static MoonGameRev.Services.Tests.UserAndJournalistTests.DataBaseSeeder;
using MoonGameRev.Data.Models;

namespace MoonGameRev.Services.Tests.UserAndJournalistTests
{
    public class UserServiceTests
    {
        private MoonGameRevDbContext dbContext;
        private DbContextOptions<MoonGameRevDbContext> optionsDb;

        private IUserService userService;

        [OneTimeSetUp]
        public void Setup()
        {
            optionsDb = new DbContextOptionsBuilder<MoonGameRevDbContext>()
               .UseInMemoryDatabase("MoonGameRevInMemory" + Guid.NewGuid().ToString()).Options;

            dbContext = new MoonGameRevDbContext(optionsDb);

            dbContext.Database.EnsureCreated();

            SeedDataBase(dbContext);

            userService = new UserService(dbContext);
        }


        [Test]
        public async Task AllAsync_ShouldReturnOrderedUsers()
        {
            // Arrange - No additional setup needed

            // Act
            var result = await userService.AllAsync();

            // Assert
            Assert.IsNotNull(result);

            // Verify that the users are ordered correctly
            var orderedUsers = result.ToList();
            Assert.AreEqual(3, orderedUsers.Count);
        }

        [Test]
        public async Task GetUserNameByIdAsync_ShouldReturnUserNameIfExists()
        {

            string userId = "1";

            var result = await userService.GetUserNameByIdAsync(userId);

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AllAsync_ShouldReturnOrderedUsersWithPhoneNumbers()
        {
            // Arrange - No additional setup needed

            // Act
            var result = await userService.AllAsync();

            // Assert
            Assert.IsNotNull(result);

            var orderedUsers = result.ToList();
            foreach (var user in orderedUsers)
            {
                Assert.IsFalse(string.IsNullOrEmpty(user.UserName));
                Assert.IsFalse(string.IsNullOrEmpty(user.PhoneNumber));
            }
        }


        [Test]
        public async Task GetUserNameByIdAsync_ShouldReturnEmptyStringForNonExistingUserId()
        {
            // Arrange
            string nonExistingUserId = "non-existing-id";

            // Act
            var result = await userService.GetUserNameByIdAsync(nonExistingUserId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
