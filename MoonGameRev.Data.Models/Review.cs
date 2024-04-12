namespace MoonGameRev.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MoonGameRev.Common.EntityValidationConstants;
    using static MoonGameRev.Common.EntityValidationConstants.Review;

    [Comment("Review for a game")]
    public class Review
    {
        [Key]
        [Comment("Unique identifier for the review.")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Rating given by the user for the game")]
        public double Rating { get; set; }

        [Required]
        [Comment("The Pros of the game")]
        [MaxLength(CommentMaxLength)]
        public string Pros { get; set; } = null!;

        [Required]
        [Comment("The Cons of the game")]
        [MaxLength(CommentMaxLength)]
        public string Cons { get; set; } = null!;


        [Comment("Comment provided by the user for the review.")]
        [MaxLength(CommentMaxLength)]
        public string Comment { get; set; }

        [Required]
        [Comment("Date and time when the review was submitted.")]
        public DateTime ReviewDate { get; set; }


        public Guid GameID { get; set; }
        [ForeignKey(nameof(GameID))]
        public Game Game { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
