namespace MoonGameRev.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;
    using static MoonGameRev.Common.EntityValidationConstants.News;

    public class NewsFormModel
    {
        [Required]
        [StringLength(TitleMaxLength), MinLength(TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "The Picture link field is required.")]
        [Display(Name = "Picture link")]
        [RegularExpression(@"^(https?://)?\S+\.(jpg|jpeg|png|gif)(\?\S*)?$", ErrorMessage = "Invalid image URL format. The link needs to be an image URL")]
        public string PictureUrl { get; set; } = null!;


        [Required]
        [StringLength (ArticleMaxLength), MinLength (ArticleMinLength)]
        public string Article { get; set; } = null!;

    }
}
