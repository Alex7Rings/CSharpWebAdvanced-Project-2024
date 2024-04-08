using MoonGameRev.Web.ViewModels.News;

namespace MoonGameRev.Services.Data.Interfaces
{
    public interface INewsService
    {
        Task CreateAsync(NewsFormModel formModel, string journalistId);
    }
}
