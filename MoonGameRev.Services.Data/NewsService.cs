using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data.Models.News;
using MoonGameRev.Web.ViewModels.News;

namespace MoonGameRev.Services.Data
{
    public class NewsService : INewsService
    {
        private readonly MoonGameRevDbContext dbContext;

        public NewsService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllNewsFilteredAndPagedServiceModel> AllAsync(AllNewsQueryModel queryModel)
        {
            IQueryable<News> newsQuery = this.dbContext.News.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                newsQuery = newsQuery.Where(n => EF.Functions.Like(n.Title, wildCard) || EF.Functions.Like(n.Article, wildCard));
            }

            int totalNews = await newsQuery.CountAsync(); 


            int totalPages = (int)Math.Ceiling((double)totalNews / queryModel.NewsPerPage);

            if (queryModel.CurrentPage > totalPages)
            {
                queryModel.CurrentPage = totalPages;
            }

            IEnumerable<NewsAllViewModel> allNews = await newsQuery
                .OrderByDescending(n => n.Date)
                .Skip((queryModel.CurrentPage - 1) * queryModel.NewsPerPage)
                .Take(queryModel.NewsPerPage)
                .Select(n => new NewsAllViewModel
                {
                    Id = n.Id.ToString(),
                    Title = n.Title,
                    PictureUrl = n.PictureUrl,
                    Date = n.Date.ToString()
                })
                .ToListAsync();

            return new AllNewsFilteredAndPagedServiceModel()
            {
                TotalNewsCount = totalNews,
                News = allNews,
            };
        }

        public async Task<IEnumerable<NewsAllViewModel>> AllByJournalistIdAsync(string journalistID)
        {
            return await this.dbContext.News
                .Where(n => n.JournalistId.ToString() == journalistID)
                .Select(j => new NewsAllViewModel
                {
                    Id = j.Id.ToString(),
                    Title = j.Title,
                    PictureUrl = j.PictureUrl,
                    Date = j.Date.ToString()
                })
                .ToListAsync();
        }

        public async Task<string> CreateAsync(NewsFormModel formModel, string journalistId)
        {
            News news = new News()
            {
                Title = formModel.Title,
                PictureUrl = formModel.PictureUrl,
                Article = formModel.Article,
                JournalistId = int.Parse(journalistId)
            };

            await this.dbContext.News.AddAsync(news);
            await this.dbContext.SaveChangesAsync();

            return news.Id.ToString();
        }

        public async Task DeleteByIdAsync(string newsId)
        {
            News newsToDelete = await this.dbContext
                .News
                .FirstAsync(n => n.Id.ToString() == newsId);

            this.dbContext.News.Remove(newsToDelete);

            
            await this.dbContext.SaveChangesAsync();

        }

        public async Task EditNewsByIdAndFormModelAsync(string newsId, NewsFormModel model)
		{
            News news = await this.dbContext
                .News
                .FirstAsync(n => n.Id.ToString() == newsId);

            news.Title = model.Title;
            news.PictureUrl = model.PictureUrl;
            news.Article = model.Article;

            await this.dbContext.SaveChangesAsync();
		}

		public async Task<bool> ExistsByIdAsync(string newsId)
        {
            bool result = await this.dbContext
                .News
                .AnyAsync(n=>n.Id.ToString() == newsId);

            return result;
        }

        public async Task<NewsDetailsViewModel> GetDetailsByIdAsync(string newsId)
        {
            News news = await this.dbContext
                .News
                .Include(n=>n.Journalist)
                .ThenInclude(j=>j.User)
                .FirstAsync(n => n.Id.ToString() == newsId);


            return new NewsDetailsViewModel()
            {
                Id= newsId,
                Title = news.Title,
                JournalistId = news.JournalistId.ToString(),
                AuthorName = news.Journalist.User.Email,
                Date = news.Date.ToString(),
                PictureUrl= news.PictureUrl,
                Article = news.Article
            };
        }

        public async Task<NewsPreDeleteDetailsViewModel> GetNewsForDeleteByIdAsync(string newsId)
        {
            News news = await this.dbContext
                .News
                .FirstAsync(n=>n.Id.ToString()==newsId);

            return new NewsPreDeleteDetailsViewModel()
            {
                Title = news.Title,
                ImageUrl = news.PictureUrl,
                Article = news.Article
            };
        }

        public async Task<NewsFormModel> GetNewsForEditAsync(string id)
        {
            News news = await this.dbContext
                .News
                .FirstAsync(n => n.Id.ToString() == id);

            return new NewsFormModel
            {
                Title = news.Title,
                PictureUrl = news.PictureUrl,
                Article = news.Article
            };
        }

        public async Task<bool> IsJournalistWithIdOwnerOfTheNewsIdAsync(string newsId, string journalistID)
        {
            News news = await this.dbContext
                .News
                .FirstAsync(n=>n.Id.ToString() == newsId);

            return news.JournalistId.ToString() == journalistID;
        }
    }
}
