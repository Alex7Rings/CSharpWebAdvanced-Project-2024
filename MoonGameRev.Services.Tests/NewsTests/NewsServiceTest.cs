using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data;
using static MoonGameRev.Services.Tests.NewsTests.NewsDataBaseSeeder;
using MoonGameRev.Web.ViewModels.News;

namespace MoonGameRev.Services.Tests.NewsTests
{
	public class NewsServiceTest
	{
		private MoonGameRevDbContext dbContext;
		private DbContextOptions<MoonGameRevDbContext> optionsDb;

		private INewsService newsService;

		[SetUp]
		public void Setup()
		{
			optionsDb = new DbContextOptionsBuilder<MoonGameRevDbContext>()
			   .UseInMemoryDatabase("MoonGameRevInMemory" + Guid.NewGuid().ToString()).Options;

			dbContext = new MoonGameRevDbContext(optionsDb);

			dbContext.Database.EnsureCreated();

			NewsSeedDataBase(dbContext);

			newsService = new NewsService(dbContext);
		}

		[Test]
		public async Task AllAsync_ShouldReturnFilteredAndPagedNews()
		{
			// Arrange
			var queryModel = new AllNewsQueryModel
			{
				SearchString = "test",
				NewsPerPage = 10,
				CurrentPage = 1
			};

			// Act
			var result = await newsService.AllAsync(queryModel);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.News.Count()); // Assuming there are 2 news articles containing "test" in the title or article
			Assert.AreEqual(2, result.TotalNewsCount); // Assuming there are 2 news articles containing "test" in the title or article
		}

		[Test]
		public async Task AllByJournalistIdAsync_ShouldReturnNewsByJournalist()
		{
			// Arrange
			var journalistId = "1"; // Assuming the journalist ID is "1" for the seeded journalist

			// Act
			var result = await newsService.AllByJournalistIdAsync(journalistId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count()); // Assuming there are 2 news articles associated with the journalist
			Assert.IsTrue(result.All(n => n.Id == NewsDataBaseSeeder.News1.Id.ToString() || n.Id == NewsDataBaseSeeder.News2.Id.ToString())); // Assuming News1 and News2 are associated with the journalist
		}

		[Test]
		public async Task CreateAsync_ShouldCreateNewNewsAndReturnId()
		{
			// Arrange
			var formModel = new NewsFormModel
			{
				Title = "New Test News",
				PictureUrl = "test_picture_url",
				Article = "This is a test article for the CreateAsync method."
			};

			var journalistId = NewsDataBaseSeeder.Journalist1.Id.ToString();

			// Act
			var result = await newsService.CreateAsync(formModel, journalistId);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(Guid.TryParse(result, out _)); // Ensure the result is a valid Guid
			Assert.IsTrue(dbContext.News.Any(n => n.Title == "New Test News")); // Check if the news was added to the database
		}

		[Test]
		public async Task DeleteByIdAsync_ShouldDeleteNewsById()
		{
			// Arrange
			var newsToDelete = NewsDataBaseSeeder.News1;
			var newsIdToDelete = newsToDelete.Id.ToString();

			// Act
			await newsService.DeleteByIdAsync(newsIdToDelete);

			// Assert
			Assert.IsFalse(dbContext.News.Any(n => n.Id.ToString() == newsIdToDelete)); // Ensure the news with the specified ID does not exist in the database
		}

		[Test]
		public async Task EditNewsByIdAndFormModelAsync_ShouldEditNews()
		{
			// Arrange
			var newsToEdit = NewsDataBaseSeeder.News1;
			var newsIdToEdit = newsToEdit.Id;
			var originalTitle = newsToEdit.Title;
			var newTitle = "New Title";

			var newsFormModel = new NewsFormModel
			{
				Title = newTitle,
				PictureUrl = newsToEdit.PictureUrl,
				Article = newsToEdit.Article
			};

			// Act
			await newsService.EditNewsByIdAndFormModelAsync(newsIdToEdit.ToString(), newsFormModel);

			// Assert
			var editedNews = await dbContext.News.FindAsync(newsIdToEdit);
			Assert.IsNotNull(editedNews);
			Assert.AreEqual(newTitle, editedNews.Title);
			Assert.AreEqual(newsToEdit.PictureUrl, editedNews.PictureUrl);
			Assert.AreEqual(newsToEdit.Article, editedNews.Article);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrueForExistingNewsId()
		{
			// Arrange
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			// Act
			var result = await newsService.ExistsByIdAsync(existingNewsId);

			// Assert
			Assert.IsTrue(result);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnFalseForNonExistingNewsId()
		{
			// Arrange
			var nonExistingNewsId = Guid.NewGuid().ToString(); // Generating a random non-existing news ID

			// Act
			var result = await newsService.ExistsByIdAsync(nonExistingNewsId);

			// Assert
			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldReturnCorrectDetailsForExistingNewsId()
		{
			// Arrange
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			// Act
			var result = await newsService.GetDetailsByIdAsync(existingNewsId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(existingNewsId, result.Id);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Title, result.Title);
			Assert.AreEqual(NewsDataBaseSeeder.Journalist1.User.Email, result.AuthorName);
			// Add more assertions for other properties as needed
		}

		[Test]
		public async Task GetNewsForDeleteByIdAsync_ShouldReturnCorrectDetailsForExistingNewsId()
		{
			// Arrange
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			// Act
			var result = await newsService.GetNewsForDeleteByIdAsync(existingNewsId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Title, result.Title);
			Assert.AreEqual(NewsDataBaseSeeder.News1.PictureUrl, result.ImageUrl);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Article, result.Article);
			// Add more assertions for other properties as needed
		}

		[Test]
		public async Task GetNewsForEditAsync_ShouldReturnCorrectDetailsForExistingNewsId()
		{
			// Arrange
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			// Act
			var result = await newsService.GetNewsForEditAsync(existingNewsId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Title, result.Title);
			Assert.AreEqual(NewsDataBaseSeeder.News1.PictureUrl, result.PictureUrl);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Article, result.Article);
			// Add more assertions for other properties as needed
		}

		[Test]
		public async Task IsJournalistWithIdOwnerOfTheNewsIdAsync_ShouldReturnTrueForMatchingJournalistIdAndNewsId()
		{
			// Arrange
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();
			var journalistId = NewsDataBaseSeeder.Journalist1.Id.ToString(); // Assuming Journalist1 is the owner of the seeded news

			// Act
			var result = await newsService.IsJournalistWithIdOwnerOfTheNewsIdAsync(existingNewsId, journalistId);

			// Assert
			Assert.IsTrue(result);
		}



	}
}
