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
            IQueryable<News> newsQuery = this.dbContext
                .News
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                newsQuery = newsQuery
                    .Where(n => EF.Functions.Like(n.Title, wildCard) ||
                                EF.Functions.Like(n.Article, wildCard));
            }

            IEnumerable<NewsAllViewModel> allNews = await newsQuery
                .Skip((queryModel.CurrentPage -1) * queryModel.NewsPerPage)
                .Take(queryModel.NewsPerPage)
                .Select(n=> new NewsAllViewModel
                {
                    Id = n.Id.ToString(),
                    Title = n.Title,
                    PictureUrl = n.PictureUrl,
                    Date = n.Date.ToString()
                })
                .OrderBy(n => n.Date)
                .ToArrayAsync();

            int totalNews = newsQuery.Count();

            return new AllNewsFilteredAndPagedServiceModel()
            {
                TotalNewsCount = totalNews,
                News = allNews
            };
        }

        public async Task CreateAsync(NewsFormModel formModel, string journalistId)
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
        }
    }
}
