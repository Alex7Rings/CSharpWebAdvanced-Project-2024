using Microsoft.EntityFrameworkCore;
using MoonGameRev.Data;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Web.ViewModels.Genre;

namespace MoonGameRev.Services.Data
{
    public class GenreService : IGenreService
    {
        private readonly MoonGameRevDbContext dbContext;

        public GenreService(MoonGameRevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GameSelectGenreFormModel>> AllGenresAsync()
        {
            IEnumerable<GameSelectGenreFormModel> allGenres = await this.dbContext
                .Genres
                .AsNoTracking()
                .Select(g=> new GameSelectGenreFormModel()
                {
                    Id = g.GenreID, 
                    Name = g.Name,
                })
                .ToArrayAsync();

            return allGenres;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Genres
                .AnyAsync(g => g.GenreID == id);

            return result;    
        }
    }
}
