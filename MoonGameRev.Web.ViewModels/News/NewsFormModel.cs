using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.EntityValidationConstants.News;

namespace MoonGameRev.Web.ViewModels.News
{
    public class NewsFormModel
    {
        [Required]
        [StringLength(TitleMaxLength), MinLength(TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength (PictureUrlMaxLength)]
        [Display(Name = "Picture link")]
        public string PictureUrl { get; set; } = null!;

        [Required]
        [StringLength (ArticleMaxLength), MinLength (ArticleMinLength)]
        public string Article { get; set; } = null!;

    }
}
