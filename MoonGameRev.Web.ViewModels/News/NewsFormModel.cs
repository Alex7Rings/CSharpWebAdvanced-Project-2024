namespace MoonGameRev.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;
    using static MoonGameRev.Common.EntityValidationConstants.News;

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
