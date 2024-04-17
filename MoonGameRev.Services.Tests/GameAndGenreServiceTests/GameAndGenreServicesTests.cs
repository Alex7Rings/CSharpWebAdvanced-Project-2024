using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Game;
using MoonGameRev.Web.ViewModels.Game.Enums;
using MoonGameRev.Web.ViewModels.Home;
using System.Globalization;
using static MoonGameRev.Services.Tests.GameServiceTests.GameDataBaseSeeder;

namespace MoonGameRev.Services.Tests.GameServiceTests
{
	public class GameAndGenreServicesTests
	{
		private MoonGameRevDbContext dbContext;
		private DbContextOptions<MoonGameRevDbContext> optionsDb;

		private IGameService gameService;
		private IGenreService genreService;

		[SetUp]
		public void Setup()
		{
			optionsDb = new DbContextOptionsBuilder<MoonGameRevDbContext>()
			   .UseInMemoryDatabase("MoonGameRevInMemory" + Guid.NewGuid().ToString()).Options;

			dbContext = new MoonGameRevDbContext(optionsDb);

			dbContext.Database.EnsureCreated();

			GameSeedDataBase(dbContext);


			gameService = new GameService(dbContext);

			genreService = new GenreService(dbContext);
		}


		[Test]
		public async Task GetGameForEditByIdAsync_ShouldReturnGameFormModel()
		{

			string gameId = GameDataBaseSeeder.Game1.Id.ToString();

			var formModel = await gameService.GetGameForEditByIdAsync(gameId);

			Assert.IsNotNull(formModel);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Title, formModel.Title);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Description, formModel.Description);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Developer, formModel.Developer);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Publisher, formModel.Publisher);
			Assert.AreEqual(GameDataBaseSeeder.Game1.GameSite, formModel.GameSite);
			Assert.AreEqual(GameDataBaseSeeder.Game1.ReleaseDate.ToShortDateString(), formModel.ReleaseDate);
			Assert.AreEqual(GameDataBaseSeeder.Game1.CoverImage, formModel.CoverImage);
			Assert.AreEqual(GameDataBaseSeeder.Game1.IsReleased, formModel.IsReleased);
			CollectionAssert.AreEquivalent(new List<int> { Genre1.GenreID, Genre2.GenreID }, formModel.GenreIds.ToList());
		}

		[Test]
		public async Task AllAsync_ShouldReturnFilteredAndPagedGames()
		{
			var queryModel = new AllGamesQueryModel
			{
				Genre = "Action",
				SearchString = "",
				GameSorting = GameSorting.Newest,
				CurrentPage = 1,
				GamesPerPage = 10
			};

			var result = await gameService.AllAsync(queryModel);

			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Games.Count());

		}

		[Test]
		public async Task CreateAsync_ShouldCreateNewGame()
		{
			var formModel = new GameFormModel
			{
				Title = "New Game",
				Description = "Description of New Game",
				Developer = "New Developer",
				Publisher = "New Publisher",
				GameSite = "http://newgamesite.com",
				ReleaseDate = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy"),
				CoverImage = "new_cover_image_url",
				IsReleased = false,
			};

			var gameId = await gameService.CreateAsync(formModel);

			Assert.IsNotNull(gameId);

			var createdGame = await dbContext.Games.FindAsync(Guid.Parse(gameId));
			Assert.IsNotNull(createdGame);
			Assert.AreEqual(formModel.Title, createdGame.Title);
			Assert.AreEqual(formModel.Description, createdGame.Description);
			Assert.AreEqual(formModel.Developer, createdGame.Developer);
			Assert.AreEqual(formModel.Publisher, createdGame.Publisher);
			Assert.AreEqual(formModel.GameSite, createdGame.GameSite);
			Assert.AreEqual(formModel.IsReleased, createdGame.IsReleased);
			Assert.AreEqual(formModel.CoverImage, createdGame.CoverImage);

			var associatedGenres = await dbContext.GameGenres
				.Where(gg => gg.GameID == createdGame.Id)
				.Select(gg => gg.GenreID)
				.ToListAsync();

			Assert.AreEqual(formModel.GenreIds.Count, associatedGenres.Count);
			foreach (var genreId in formModel.GenreIds)
			{
				Assert.Contains(genreId, associatedGenres);
			}
		}


		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrueIfGameExists()
		{
			string existingGameId = GameDataBaseSeeder.Game1.Id.ToString();


			bool exists = await gameService.ExistsByIdAsync(existingGameId);

			Assert.IsTrue(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnFalseIfGameDoesNotExist()
		{

			string nonExistingGameId = Guid.NewGuid().ToString();

			bool exists = await gameService.ExistsByIdAsync(nonExistingGameId);

			Assert.IsFalse(exists);
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldReturnGameDetailsViewModel()
		{


			string gameId = GameDataBaseSeeder.Game1.Id.ToString();


			var viewModel = await gameService.GetDetailsByIdAsync(gameId);

			Assert.IsNotNull(viewModel);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Id.ToString(), viewModel.Id);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Title, viewModel.Title);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Description, viewModel.Description);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Developer, viewModel.Developer);
			Assert.AreEqual(GameDataBaseSeeder.Game1.Publisher, viewModel.Publisher);
			Assert.AreEqual(GameDataBaseSeeder.Game1.GameSite, viewModel.GameSite);
			Assert.AreEqual(GameDataBaseSeeder.Game1.ReleaseDate.ToShortDateString(), viewModel.ReleaseDate);
			Assert.AreEqual(GameDataBaseSeeder.Game1.CoverImage, viewModel.ImageUrl);
			Assert.AreEqual(GameDataBaseSeeder.Game1.IsReleased, viewModel.IsReleased);
		}

		[Test]
		public async Task EditGameByIdAndFormModel_ShouldUpdateGameAndGenres()
		{

			string gameId = GameDataBaseSeeder.Game1.Id.ToString();
			var formModel = new GameFormModel
			{
				Title = "Updated Title",
				Description = "Updated Description",
				Developer = "Updated Developer",
				Publisher = "Updated Publisher",
				GameSite = "http://updatedgamesite.com",
				ReleaseDate = DateTime.Now.AddDays(30).ToString("dd/MM/yyyy"),
				CoverImage = "updated_cover_image_url",
				IsReleased = true
			};

			await gameService.EditGameByIdAndFormModel(gameId, formModel);

			var updatedGame = dbContext.Games.FirstOrDefault(g => g.Id.ToString() == gameId);
			Assert.IsNotNull(updatedGame);
			Assert.AreEqual(formModel.Title, updatedGame.Title);
			Assert.AreEqual(formModel.Description, updatedGame.Description);
			Assert.AreEqual(formModel.Developer, updatedGame.Developer);
			Assert.AreEqual(formModel.Publisher, updatedGame.Publisher);
			Assert.AreEqual(formModel.GameSite, updatedGame.GameSite);
			Assert.AreEqual(formModel.CoverImage, updatedGame.CoverImage);
			Assert.AreEqual(DateTime.ParseExact(formModel.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), updatedGame.ReleaseDate);
			Assert.AreEqual(formModel.IsReleased, updatedGame.IsReleased);

			// Check if genres are updated
			var updatedGenreIds = updatedGame.GameGenres.Select(gg => gg.GenreID).ToList();
			CollectionAssert.AreEqual(formModel.GenreIds, updatedGenreIds);
		}

		[Test]
		public async Task AllGenresAsync_ShouldReturnAllGenres()
		{
			var result = await genreService.AllGenresAsync();

			Assert.IsNotNull(result);
			Assert.AreEqual(28, result.Count());
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrueForExistingGenreId()
		{
			int existingGenreId = 1;

			bool exists = await genreService.ExistsByIdAsync(existingGenreId);

			Assert.IsTrue(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnFalseForNonExistingGenreId()
		{
			int nonExistingGenreId = 1000;

			bool exists = await genreService.ExistsByIdAsync(nonExistingGenreId);

			Assert.IsFalse(exists);
		}

		[Test]
		public async Task LastFiveGamesAsync_ReturnsLastFiveReleasedGames()
		{
			var expectedLastFiveReleasedGames = await dbContext.Games
				.Where(g => g.IsReleased)
				.OrderByDescending(g => g.Reviews.Count())
				.Take(5)
				.Select(g => new IndexViewModel
				{
					Id = g.Id.ToString(),
					Title = g.Title,
					ImageUrl = g.CoverImage,
					IsReleased = g.IsReleased
				})
				.ToArrayAsync();

			var lastFiveReleasedGames = await gameService.LastFiveGamesAsync();

			Assert.IsNotNull(lastFiveReleasedGames);
			Assert.AreEqual(5, lastFiveReleasedGames.Count());

			for (int i = 0; i < expectedLastFiveReleasedGames.Length; i++)
			{
				Assert.AreEqual(expectedLastFiveReleasedGames[i].Id, lastFiveReleasedGames.ElementAt(i).Id);
				Assert.AreEqual(expectedLastFiveReleasedGames[i].Title, lastFiveReleasedGames.ElementAt(i).Title);
				Assert.AreEqual(expectedLastFiveReleasedGames[i].ImageUrl, lastFiveReleasedGames.ElementAt(i).ImageUrl);
				Assert.AreEqual(expectedLastFiveReleasedGames[i].IsReleased, lastFiveReleasedGames.ElementAt(i).IsReleased);
			}
		}

		[Test]
		public async Task LastFiveUpcomingGamesAsync_ReturnsLastFiveUpcomingGames()
		{
			var expectedLastFiveUpcomingGames = await dbContext.Games
				.Where(g => !g.IsReleased)
				.OrderBy(g => g.ReleaseDate)
				.Take(5)
				.Select(g => new IndexViewModel
				{
					Id = g.Id.ToString(),
					Title = g.Title,
					ImageUrl = g.CoverImage,
					IsReleased = g.IsReleased
				})
				.ToArrayAsync();

			var lastFiveUpcomingGames = await gameService.LastFiveUpcomingGamesAsync();

			Assert.IsNotNull(lastFiveUpcomingGames);
			Assert.AreEqual(5, lastFiveUpcomingGames.Count());

			for (int i = 0; i < expectedLastFiveUpcomingGames.Length; i++)
			{
				Assert.AreEqual(expectedLastFiveUpcomingGames[i].Id, lastFiveUpcomingGames.ElementAt(i).Id);
				Assert.AreEqual(expectedLastFiveUpcomingGames[i].Title, lastFiveUpcomingGames.ElementAt(i).Title);
				Assert.AreEqual(expectedLastFiveUpcomingGames[i].ImageUrl, lastFiveUpcomingGames.ElementAt(i).ImageUrl);
				Assert.AreEqual(expectedLastFiveUpcomingGames[i].IsReleased, lastFiveUpcomingGames.ElementAt(i).IsReleased);
			}
		}
	}
}
