namespace MoonGameRev.Services.Tests.UserAndJournalistTests
{
    using Microsoft.EntityFrameworkCore;
    using MoonGameRev.Data;
    using MoonGameRev.Services.Data;
    using MoonGameRev.Services.Data.Interfaces;
    using static MoonGameRev.Services.Tests.UserAndJournalistTests.DataBaseSeeder;


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
            var result = await userService.AllAsync();

            Assert.IsNotNull(result);

            var orderedUsers = result.ToList();
            Assert.AreEqual(5, orderedUsers.Count);
        }

        [Test]
        public async Task GetUserNameByIdAsync_ShouldReturnUserNameIfExists()
        {

            string userId = "1";

            var result = await userService.GetUserNameByIdAsync(userId);

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetUserNameByIdAsync_ShouldReturnEmptyStringForNonExistingUserId()
        {
            string nonExistingUserId = "non-existing-id";

            var result = await userService.GetUserNameByIdAsync(nonExistingUserId);

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
