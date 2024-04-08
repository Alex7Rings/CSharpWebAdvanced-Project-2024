using MoonGameRev.Data;
using MoonGameRev.Data.Models;
using MoonGameRev.Services.Data.Interfaces;
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
