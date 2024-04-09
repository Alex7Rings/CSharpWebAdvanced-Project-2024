using MoonGameRev.Services.Data.Models.News;
using MoonGameRev.Web.ViewModels.News;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface INewsService
    {
        Task<string> CreateAsync(NewsFormModel formModel, string journalistId);

        Task<AllNewsFilteredAndPagedServiceModel> AllAsync(AllNewsQueryModel queryModel);

        Task<IEnumerable<NewsAllViewModel>> AllByJournalistIdAsync(string journalistID);

        Task<NewsDetailsViewModel> GetDetailsByIdAsync(string newsId);

        Task<bool> ExistsByIdAsync(string newsId);

        Task<NewsFormModel> GetNewsForEditAsync(string id);

        Task<bool> IsJournalistWithIdOwnerOfTheNewsIdAsync(string newsId, string journalistID);

        Task EditNewsByIdAndFormModel(string newsId, NewsFormModel model);
    }
}
