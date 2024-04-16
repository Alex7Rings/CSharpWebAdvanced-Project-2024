using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Journalist;
using static MoonGameRev.Services.Tests.DataBaseSeeder;

namespace MoonGameRev.Services.JournalistServiceTests
{
	public class JournalistServiceTests
	{
		private MoonGameRevDbContext dbContext;
		private DbContextOptions<MoonGameRevDbContext> optionsDb;

		private IJournalistService journalistService;

		[OneTimeSetUp]
		public void Setup()
		{
			this.optionsDb = new DbContextOptionsBuilder<MoonGameRevDbContext>()
			   .UseInMemoryDatabase("MoonGameRevInMemory" + Guid.NewGuid().ToString()).Options;

			this.dbContext = new MoonGameRevDbContext(this.optionsDb);

			dbContext.Database.EnsureCreated();

			SeedDataBase(this.dbContext);

			this.journalistService = new JournalistService(this.dbContext);
		}

		[Test]
		public async Task JournalistExistsByUserIdAsyncShoudReturnTrueWhenExists()
		{
			string existingJournalistUserId = User.Id.ToString();

			bool result =  await this.journalistService.JournalistExistsByUserIdAsync(existingJournalistUserId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task CreateAsync_ShouldCreateJournalistAndSaveToDatabase()
		{
			// Arrange
			string userId = Guid.NewGuid().ToString();
			var model = new BecomeJournalistFormModel { PhoneNumber = "1234567890" };

			// Act
			await this.journalistService.CreateAsync(userId, model);

			// Assert
			var createdJournalist = await this.dbContext.Journalists.FirstOrDefaultAsync(j => j.UserId.ToString() == userId);
			Assert.NotNull(createdJournalist);
			Assert.AreEqual(model.PhoneNumber, createdJournalist.PhoneNumber);
		}

		[Test]
		public async Task GetJournalistIdByUserIdAsync_ShouldReturnNullIfNotExists()
		{
			// Arrange: No journalist exists in the database

			// Act
			string? journalistId = await this.journalistService.GetJournalistIdByUserIdAsync("nonExistentUserId");

			// Assert
			Assert.IsNull(journalistId);
		}

		[Test]
		public async Task JournalistExistsByPhoneNumberAsync_ShouldReturnTrueIfJournalistExistsWithPhoneNumber()
		{
			// Arrange
			string phoneNumber = "1234567890";
			var existingJournalist = new Journalist { UserId = User.Id, PhoneNumber = phoneNumber };
			await this.dbContext.Journalists.AddAsync(existingJournalist);
			await this.dbContext.SaveChangesAsync();

			// Act
			bool result = await this.journalistService.JournalistExistsByPhoneNumberAsync(phoneNumber);

			// Assert
			Assert.IsTrue(result);
		}

		[Test]
		public async Task JournalistExistsByPhoneNumberAsync_ShouldReturnFalseIfJournalistDoesNotExistWithPhoneNumber()
		{
			// Arrange - No need to add any Journalist entities to the database

			// Act
			bool result = await this.journalistService.JournalistExistsByPhoneNumberAsync("12345678770");

			// Assert
			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetJournalistIdByUserIdAsync_ShouldReturnJournalistIdIfExists()
		{
			// Arrange
			var existingJournalist = new Journalist { UserId = Guid.NewGuid(), PhoneNumber = "+1234567890" };
			dbContext.Journalists.Add(existingJournalist);
			await dbContext.SaveChangesAsync();

			// Act
			var journalistId = await journalistService.GetJournalistIdByUserIdAsync(existingJournalist.UserId.ToString());

			// Assert
			Assert.IsNotNull(journalistId);
			Assert.AreEqual(existingJournalist.Id.ToString(), journalistId);
		}

		[Test]
		public async Task JournalistExistsByUserIdAsync_ShouldReturnTrueIfJournalistExistsWithUserId()
		{
			// Arrange
			var userId = Guid.NewGuid().ToString();
			var existingJournalist = new Journalist { UserId = Guid.Parse(userId), PhoneNumber = "+1234567890" };
			dbContext.Journalists.Add(existingJournalist);
			await dbContext.SaveChangesAsync();

			// Act
			var result = await journalistService.JournalistExistsByUserIdAsync(userId);

			// Assert
			Assert.IsTrue(result);
		}
	}
}