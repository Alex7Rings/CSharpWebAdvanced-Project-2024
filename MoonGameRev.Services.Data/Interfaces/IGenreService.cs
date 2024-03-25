using MoonGameRev.Web.ViewModels.Genre;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GameSelectGenreFormModel>> AllGenresAsync();

        Task<bool> ExistsByIdAsync(int id);
    }
}
