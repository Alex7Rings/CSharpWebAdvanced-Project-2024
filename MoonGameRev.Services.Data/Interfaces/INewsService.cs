using MoonGameRev.Services.Data.Models.News;
using MoonGameRev.Web.ViewModels.News;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface INewsService
    {
        Task CreateAsync(NewsFormModel formModel, string journalistId);

        Task<AllNewsFilteredAndPagedServiceModel> AllAsync(AllNewsQueryModel queryModel);
    }
}
