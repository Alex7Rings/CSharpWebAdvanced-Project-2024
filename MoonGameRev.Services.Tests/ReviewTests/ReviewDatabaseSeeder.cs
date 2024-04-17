using MoonGameRev.Data;
using MoonGameRev.Data.Models;

namespace MoonGameRev.Services.Tests.ReviewTests
{
	public static class ReviewDatabaseSeeder
	{
		public static AppUser User1;
		public static AppUser User2;

		public static Game Game1;
		public static Game Game2;

		public static Review Review1;
		public static Review Review2;


		public static void ReviewSeedDatabase ( MoonGameRevDbContext dbContext)
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

			User2 = new AppUser()
			{
				UserName = "TestUser2",
				NormalizedUserName = "TESTUSER2",
				Email = "TestUser2@test.com",
				NormalizedEmail = "TESTUSER2@TEST.COM",
				EmailConfirmed = true,
				PasswordHash = "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee402a0",
				ConcurrencyStamp = "f73d8fc7-acd4-487b-842a-d8ad31881860",
				SecurityStamp = "0ca5e7e7-55c8-4028-ae09-9e8ebb8d0a60",
				TwoFactorEnabled = false,
			};

			dbContext.Users.AddRange(User1, User2);

			Game1 = new Game()
			{
				Title = "Game 1",
				Description = "Description of Game 1",
				Developer = "Developer 1",
				Publisher = "Publisher 1",
				GameSite = "http://gamesite1.com",
				ReleaseDate = DateTime.Parse("2023-01-01"),
				CoverImage = "cover_image_url_1",
				IsReleased = true
			};

			Game2 = new Game()
			{
				Title = "Game 2",
				Description = "Description of Game 2",
				Developer = "Developer 2",
				Publisher = "Publisher 2",
				GameSite = "http://gamesite2.com",
				ReleaseDate = DateTime.Parse("2024-02-02"),
				CoverImage = "cover_image_url_2",
				IsReleased = false
			};

			dbContext.Games.AddRange(Game1, Game2);

			Review1 = new Review()
			{
				Rating = 4.5,
				Pros = "Pros of review 1",
				Cons = "Cons of review 1",
				Comment = "Comment of review 1",
				GameID = Game1.Id,
				UserId = User1.Id
			};

			Review2 = new Review()
			{
				Rating = 3.8,
				Pros = "Pros of review 2",
				Cons = "Cons of review 2",
				Comment = "Comment of review 2",
				GameID = Game2.Id,
				UserId = User1.Id
			};

			dbContext.Reviews.AddRange(Review1, Review2);

			dbContext.SaveChanges();
		}
	}
}
