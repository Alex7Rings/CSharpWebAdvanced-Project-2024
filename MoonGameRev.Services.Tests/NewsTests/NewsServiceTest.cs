using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data;
using static MoonGameRev.Services.Tests.NewsTests.NewsDataBaseSeeder;
using MoonGameRev.Web.ViewModels.News;
using MoonGameRev.Web.ViewModels.Home;

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
			var queryModel = new AllNewsQueryModel
			{
				SearchString = "test",
				NewsPerPage = 10,
				CurrentPage = 1
			};

			var result = await newsService.AllAsync(queryModel);

			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.News.Count()); 
			Assert.AreEqual(2, result.TotalNewsCount); 
		}

		[Test]
		public async Task AllByJournalistIdAsync_ShouldReturnNewsByJournalist()
		{
			var journalistId = "1"; 

			var result = await newsService.AllByJournalistIdAsync(journalistId);

			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count()); 
			Assert.IsTrue(result.All(n => n.Id == NewsDataBaseSeeder.News1.Id.ToString() || n.Id == NewsDataBaseSeeder.News2.Id.ToString())); 
		}

		[Test]
		public async Task CreateAsync_ShouldCreateNewNewsAndReturnId()
		{
			var formModel = new NewsFormModel
			{
				Title = "New Test News",
				PictureUrl = "test_picture_url",
				Article = "This is a test article for the CreateAsync method."
			};

			var journalistId = NewsDataBaseSeeder.Journalist1.Id.ToString();

			var result = await newsService.CreateAsync(formModel, journalistId);

			Assert.IsNotNull(result);
			Assert.IsTrue(Guid.TryParse(result, out _)); 
			Assert.IsTrue(dbContext.News.Any(n => n.Title == "New Test News")); 
		}

		[Test]
		public async Task DeleteByIdAsync_ShouldDeleteNewsById()
		{
			var newsToDelete = NewsDataBaseSeeder.News1;
			var newsIdToDelete = newsToDelete.Id.ToString();

			await newsService.DeleteByIdAsync(newsIdToDelete);

			Assert.IsFalse(dbContext.News.Any(n => n.Id.ToString() == newsIdToDelete)); 
		}

		[Test]
		public async Task EditNewsByIdAndFormModelAsync_ShouldEditNews()
		{
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

			await newsService.EditNewsByIdAndFormModelAsync(newsIdToEdit.ToString(), newsFormModel);

			var editedNews = await dbContext.News.FindAsync(newsIdToEdit);
			Assert.IsNotNull(editedNews);
			Assert.AreEqual(newTitle, editedNews.Title);
			Assert.AreEqual(newsToEdit.PictureUrl, editedNews.PictureUrl);
			Assert.AreEqual(newsToEdit.Article, editedNews.Article);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrueForExistingNewsId()
		{
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			var result = await newsService.ExistsByIdAsync(existingNewsId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnFalseForNonExistingNewsId()
		{
			var nonExistingNewsId = Guid.NewGuid().ToString(); 

			var result = await newsService.ExistsByIdAsync(nonExistingNewsId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldReturnCorrectDetailsForExistingNewsId()
		{
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			var result = await newsService.GetDetailsByIdAsync(existingNewsId);

			Assert.IsNotNull(result);
			Assert.AreEqual(existingNewsId, result.Id);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Title, result.Title);
			Assert.AreEqual(NewsDataBaseSeeder.Journalist1.User.Email, result.AuthorName);
		}

		[Test]
		public async Task GetNewsForDeleteByIdAsync_ShouldReturnCorrectDetailsForExistingNewsId()
		{
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			var result = await newsService.GetNewsForDeleteByIdAsync(existingNewsId);

			Assert.IsNotNull(result);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Title, result.Title);
			Assert.AreEqual(NewsDataBaseSeeder.News1.PictureUrl, result.ImageUrl);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Article, result.Article);
		}

		[Test]
		public async Task GetNewsForEditAsync_ShouldReturnCorrectDetailsForExistingNewsId()
		{
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();

			var result = await newsService.GetNewsForEditAsync(existingNewsId);

			Assert.IsNotNull(result);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Title, result.Title);
			Assert.AreEqual(NewsDataBaseSeeder.News1.PictureUrl, result.PictureUrl);
			Assert.AreEqual(NewsDataBaseSeeder.News1.Article, result.Article);
		}

		[Test]
		public async Task IsJournalistWithIdOwnerOfTheNewsIdAsync_ShouldReturnTrueForMatchingJournalistIdAndNewsId()
		{
			var existingNewsId = NewsDataBaseSeeder.News1.Id.ToString();
			var journalistId = NewsDataBaseSeeder.Journalist1.Id.ToString(); 

			var result = await newsService.IsJournalistWithIdOwnerOfTheNewsIdAsync(existingNewsId, journalistId);

			Assert.IsTrue(result);
		}

        [Test]
        public async Task LatestNewsAsync_ReturnsLatestNews()
        {
            var expectedLatestNews = await dbContext.News
                .OrderByDescending(n => n.Date)
                .Take(2)
                .Select(n => new IndexViewModel
                {
                    NewsID = n.Id.ToString(),
                    NewsImage = n.PictureUrl,
                    NewsTitle = n.Title,
                })
                .ToArrayAsync();

            var latestNews = await newsService.LatestNewsAsync();

            Assert.IsNotNull(latestNews);
            Assert.AreEqual(2, latestNews.Count());

            for (int i = 0; i < expectedLatestNews.Length; i++)
            {
                Assert.AreEqual(expectedLatestNews[i].NewsID, latestNews.ElementAt(i).NewsID);
                Assert.AreEqual(expectedLatestNews[i].NewsImage, latestNews.ElementAt(i).NewsImage);
                Assert.AreEqual(expectedLatestNews[i].NewsTitle, latestNews.ElementAt(i).NewsTitle);
            }
        }

    }
}
