namespace MoonGameRev.Services.Data.Interfaces
{
    using MoonGameRev.Services.Data.Models.Game;
    using MoonGameRev.Web.ViewModels.Game;
    using MoonGameRev.Web.ViewModels.Home;

    public interface IGameService
    {
        string GetRatingCategory(double averageRating);

        Task<IEnumerable<IndexViewModel>> LastFiveUpcomingGamesAsync();

        Task<IEnumerable<IndexViewModel>> LastFiveGamesAsync();

        Task<string> CreateAsync(GameFormModel formModel);

        Task<AllGamesFilteredAndPagedServiceModel> AllAsync(AllGamesQueryModel queryModel);

        Task<AllUpcomingGamesPagedServiceModel> AllUpcomingGamesAsync(UpcomingGamesQueryModel queryModel);

        Task<GameDetailsViewModel> GetDetailsByIdAsync(string gameId);

        Task<bool> ExistsByIdAsync(string gameId);

        Task<GameFormModel> GetGameForEditByIdAsync(string gameId);

        Task EditGameByIdAndFormModel(string gameId, GameFormModel formModel);

    }
}
