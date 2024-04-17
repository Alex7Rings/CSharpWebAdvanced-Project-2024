namespace MoonGameRev.Services.Data.Interfaces
{
    using MoonGameRev.Web.ViewModels.Genre;

    public interface IGenreService
    {
        Task<IEnumerable<GameSelectGenreFormModel>> AllGenresAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllGenresNamesAsync();
    }
}
