using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.EntityValidationConstants.News;

namespace MoonGameRev.Data.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ArticleMaxLength)]
        public string Article { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(PictureUrlMaxLength)]
        public string PictureUrl { get; set; } = null!;

        [Required]
        public int JournalistId { get; set; } 

        public Journalist Journalist { get; set; } = null!;
    }
}
