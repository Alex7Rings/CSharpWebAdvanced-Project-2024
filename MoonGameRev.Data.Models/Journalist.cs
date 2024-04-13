using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.EntityValidationConstants.Journalist;

namespace MoonGameRev.Data.Models
{
    public class Journalist
    {
        public Journalist()
        {
            this.NewsArticles = new HashSet<News>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }

        public AppUser User { get; set; } = null!;

        public ICollection<News> NewsArticles { get; set; }
    }
}
