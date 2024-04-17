namespace MoonGameRev.Web.ViewModels.Review
{
    using MoonGameRev.Common.Attributes;
    using System.ComponentModel.DataAnnotations;
    using static MoonGameRev.Common.EntityValidationConstants.Review;


    public class ReviewFormModel
    {
        [Required]
        [CustomDecimalRange(ReviewMinRange, ReviewMaxRange)]
        public double Rating { get; set; } 

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
