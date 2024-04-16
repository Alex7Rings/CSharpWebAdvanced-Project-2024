using MoonGameRev.Data;
using MoonGameRev.Data.Models;

namespace MoonGameRev.Services.Tests.GameServiceTests
{
	public static class GameDataBaseSeeder
	{
		public static AppUser User1;
		public static AppUser User2;
		public static Game Game1;
		public static Game Game2;
		public static Game Game3;
		public static Game Game4;
		public static Genre Genre1;
		public static Genre Genre2;
		public static Genre Genre3;


		public static void GameSeedDataBase(MoonGameRevDbContext dbContext)
		{
			User1 = new AppUser()
			{
				UserName = "User1",
				NormalizedUserName = "USER1",
				Email = "user1@test.com",
				NormalizedEmail = "USER1@TEST.COM",
				EmailConfirmed = true,
				PasswordHash = "hashedpassword",
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString(),
				TwoFactorEnabled = false,
			};

			User2 = new AppUser()
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

			Game3 = new Game()
			{

				Title = "Game 3",
				Description = "Description of Game 3",
				Developer = "Developer 3",
				Publisher = "Publisher 3",
				GameSite = "http://gamesite3.com",
				ReleaseDate = DateTime.Parse("2025-03-03"),
				CoverImage = "cover_image_url_3",
				IsReleased = true,
			};

			Game4 = new Game()
			{
				Title = "Game 4",
				Description = "Description of Game 4",
				Developer = "Developer 4",
				Publisher = "Publisher 4",
				GameSite = "http://gamesite2.com",
				ReleaseDate = DateTime.Parse("2024-05-02"),
				CoverImage = "cover_image_url_2",
				IsReleased = false
			};

			dbContext.Games.AddRange(Game1, Game2, Game3);

			Genre1 = new Genre()
			{

				Name = "Action"
			};

			Genre2 = new Genre()
			{

				Name = "BR"
			};

			dbContext.Genres.AddRange(Genre1, Genre2);

			dbContext.GameGenres.AddRange(
			new GameGenre { GameID = Game1.Id, GenreID = Genre1.GenreID },
			new GameGenre { GameID = Game1.Id, GenreID = Genre2.GenreID });

			dbContext.SaveChanges();
		}
	}
}
