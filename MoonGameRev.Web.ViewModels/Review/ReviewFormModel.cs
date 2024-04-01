using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.EntityValidationConstants.Review;

namespace MoonGameRev.Web.ViewModels.Review
{
    public class ReviewFormModel
    {
        [Required]
        [Range(typeof(double), ReviewMinRange, ReviewMaxRange)]
        public string Rating { get; set; } = null!;

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = ProsAndConsMinLength)]
        public string Pros { get; set; } = null!;


        [Required]
        [StringLength(CommentMaxLength, MinimumLength = ProsAndConsMinLength)]
        public string Cons { get; set; } = null!;


        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; } = null!;

    }
}
