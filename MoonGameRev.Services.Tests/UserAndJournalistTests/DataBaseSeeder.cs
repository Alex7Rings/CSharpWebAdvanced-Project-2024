using MoonGameRev.Data;
using MoonGameRev.Data.Models;


namespace MoonGameRev.Services.Tests.UserAndJournalistTests
{
	public static class DataBaseSeeder
	{
		public static AppUser User;
		public static Journalist Journalist;

		public static void SeedDataBase(MoonGameRevDbContext dbContext)
		{

			User = new AppUser()
			{
				UserName = "TestUser",
				NormalizedUserName = "TESTUSER",
				Email = "TestUser@test.com",
				NormalizedEmail = "TESTUSER@TEST.COM",
				EmailConfirmed = true,
				PasswordHash = "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee401a0",
				ConcurrencyStamp = "f73d8fc7-acd4-487b-842a-d8ad31881880",
				SecurityStamp = "0ca5e7e7-55c8-4028-ae09-9e8ebb8d0a80",
				TwoFactorEnabled = false,
			};

			var user2 = new AppUser()
			{
				UserName = "User2",
				NormalizedUserName = "USER2",
				Email = "user2@test.com",
				NormalizedEmail = "USER2@TEST.COM",
				EmailConfirmed = true,
				PasswordHash = "hashedpassword",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString(),
				TwoFactorEnabled = false,
			};

			var user3 = new AppUser()
			{
				UserName = "User3",
				NormalizedUserName = "USER3",
				Email = "user3@test.com",
				NormalizedEmail = "USER3@TEST.COM",
				EmailConfirmed = true,
				PasswordHash = "hashedpassword",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString(),
				TwoFactorEnabled = false,
			};

			Journalist = new Journalist()
			{
				PhoneNumber = "+359886785089",
				UserId = User.Id
			};

			var journalist2 = new Journalist()
			{
				PhoneNumber = "+123456789",
				UserId = user2.Id
			};

			var journalist3 = new Journalist()
			{
				PhoneNumber = "+987654321",
				UserId = user3.Id
			};

			dbContext.Users.Add(User);
			dbContext.Users.Add(user2);
			dbContext.Users.Add(user3);

			dbContext.Journalists.Add(Journalist);
			dbContext.Journalists.Add(journalist2);
			dbContext.Journalists.Add(journalist3);

			dbContext.SaveChanges();

		}
	}
}
