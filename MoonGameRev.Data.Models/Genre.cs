namespace MoonGameRev.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static MoonGameRev.Common.EntityValidationConstants.Genre;

    [Comment("Represents a genre.")]
    public class Genre
    {
        public Genre()
        {
            this.GameGenres = new HashSet<GameGenre>();
        }

        [Key]
        [Comment("Unique identifier for the genre.")]
        public int GenreID { get; set; }

        [Required]
        [Comment("Name of the genre.")]
        [MaxLength(GenreNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
