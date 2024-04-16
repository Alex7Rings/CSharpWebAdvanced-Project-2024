using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Journalist;
using static MoonGameRev.Services.Tests.UserAndJournalistTests.DataBaseSeeder;

namespace MoonGameRev.Services.Tests.UserAndJournalistTests
{
    public class JournalistServiceTests
    {
        private MoonGameRevDbContext dbContext;
        private DbContextOptions<MoonGameRevDbContext> optionsDb;

        private IJournalistService journalistService;

        [OneTimeSetUp]
        public void Setup()
        {
            optionsDb = new DbContextOptionsBuilder<MoonGameRevDbContext>()
               .UseInMemoryDatabase("MoonGameRevInMemory" + Guid.NewGuid().ToString()).Options;

            dbContext = new MoonGameRevDbContext(optionsDb);

            dbContext.Database.EnsureCreated();

			SeedDataBase(dbContext);

            journalistService = new JournalistService(dbContext);
        }

        [Test]
        public async Task JournalistExistsByUserIdAsyncShoudReturnTrueWhenExists()
        {
            string existingJournalistUserId = User.Id.ToString();

            bool result = await journalistService.JournalistExistsByUserIdAsync(existingJournalistUserId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CreateAsync_ShouldCreateJournalistAndSaveToDatabase()
        {
            string userId = Guid.NewGuid().ToString();
            var model = new BecomeJournalistFormModel { PhoneNumber = "1234567890" };

            await journalistService.CreateAsync(userId, model);

            var createdJournalist = await dbContext.Journalists.FirstOrDefaultAsync(j => j.UserId.ToString() == userId);
            Assert.NotNull(createdJournalist);
            Assert.AreEqual(model.PhoneNumber, createdJournalist.PhoneNumber);
        }

        [Test]
        public async Task GetJournalistIdByUserIdAsync_ShouldReturnNullIfNotExists()
        {
            string? journalistId = await journalistService.GetJournalistIdByUserIdAsync("nonExistentUserId");

            Assert.IsNull(journalistId);
        }

        [Test]
        public async Task JournalistExistsByPhoneNumberAsync_ShouldReturnTrueIfJournalistExistsWithPhoneNumber()
        {
            string phoneNumber = "1234567890";
            var existingJournalist = new Journalist { UserId = User.Id, PhoneNumber = phoneNumber };
            await dbContext.Journalists.AddAsync(existingJournalist);
            await dbContext.SaveChangesAsync();

            bool result = await journalistService.JournalistExistsByPhoneNumberAsync(phoneNumber);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task JournalistExistsByPhoneNumberAsync_ShouldReturnFalseIfJournalistDoesNotExistWithPhoneNumber()
        {
            bool result = await journalistService.JournalistExistsByPhoneNumberAsync("12345678770");

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetJournalistIdByUserIdAsync_ShouldReturnJournalistIdIfExists()
        {
            var existingJournalist = new Journalist { UserId = Guid.NewGuid(), PhoneNumber = "+1234567890" };
            dbContext.Journalists.Add(existingJournalist);
            await dbContext.SaveChangesAsync();

            var journalistId = await journalistService.GetJournalistIdByUserIdAsync(existingJournalist.UserId.ToString());

            Assert.IsNotNull(journalistId);
            Assert.AreEqual(existingJournalist.Id.ToString(), journalistId);
        }

        [Test]
        public async Task JournalistExistsByUserIdAsync_ShouldReturnTrueIfJournalistExistsWithUserId()
        {
            var userId = Guid.NewGuid().ToString();
            var existingJournalist = new Journalist { UserId = Guid.Parse(userId), PhoneNumber = "+1234567890" };
            dbContext.Journalists.Add(existingJournalist);
            await dbContext.SaveChangesAsync();

            var result = await journalistService.JournalistExistsByUserIdAsync(userId);

            Assert.IsTrue(result);
        }
    }
}