namespace MoonGameRev.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static MoonGameRev.Common.EntityValidationConstants.Game;

    [Comment("Represents a game.")]
    public class Game
    {
        public Game()
        {
            this.Reviews = new HashSet<Review>();
            this.GameGenres = new HashSet<GameGenre>();
        }

        [Key]
        [Comment("Unique identifier for the game.")]
        public int Id { get; set; }

        [Required]
        [Comment("Title of the game.")]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Description of the game.")]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Developer of the game.")]
        [MaxLength (DeveloperNameMaxLength)]
        public string Developer { get; set; } = null!;

        [Required]
        [Comment("Publisher of the game.")]
        [MaxLength(PublisherNameMaxLength)]
        public string Publisher { get; set; } = null!;

        [Required]
        [Comment("Website of the game.")]
        [MaxLength(GameSiteMaxLength)]
        public string GameSite { get; set; } = null!;

        [Comment("Release date of the game.")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Comment("URL of the game's cover image.")]
        [MaxLength(ImageUrlMaxLength)]
        public string CoverImage { get; set; } = null!;

        [Required]
        [Comment("Specifies whether the game is released or upcoming.")]
        public bool IsReleased { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<GameGenre> GameGenres { get; set; }
    }
}
