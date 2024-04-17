namespace MoonGameRev.Services.Tests.NewsTests
{
    using MoonGameRev.Data;
    using MoonGameRev.Data.Models;



    public static class NewsDataBaseSeeder
	{
		public static News News1;
		public static News News2;
		public static AppUser User1;
		public static Journalist Journalist1;

		public static void NewsSeedDataBase(MoonGameRevDbContext dbContext)
		{
			User1 = new AppUser()
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

			Journalist1 = new Journalist()
			{
				PhoneNumber = "+359886785022",
				UserId = User1.Id
			};

			News1 = new News()
			{
				Title = "Test Title",
				Article = "This is a test for the test database to test the services in the newsService.",
				Date = DateTime.Now,
				PictureUrl = "PictureUrl_url_1",
				Journalist = Journalist1, 
			};

			News2 = new News()
			{
				Title = "Test Title2",
				Article = "2This is a test for the test database to test the services in the newsService.",
				Date = DateTime.Now,
				PictureUrl = "PictureUrl_url_2",
				Journalist = Journalist1, 
			};

			dbContext.Users.Add(User1);
			dbContext.News.AddRange(News1, News2); 
			dbContext.SaveChanges();
		}

	}
}
