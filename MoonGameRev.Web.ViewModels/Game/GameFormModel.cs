using MoonGameRev.Web.ViewModels.Genre;
using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.EntityValidationConstants.Game;

namespace MoonGameRev.Web.ViewModels.Game
{
    public class GameFormModel
    {
        public GameFormModel()
        {
            this.Genres = new HashSet<GameSelectGenreFormModel>();
            this.GenreIds = new HashSet<int>();
            this.IsReleased = true;
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(DeveloperNameMaxLength, MinimumLength = DeveloperNameMinLength)]
        public string Developer { get; set; } = null!;

        [Required]
        [StringLength(PublisherNameMaxLength, MinimumLength = PublisherNameMinLength)]
        public string Publisher { get; set; } = null!;

        [Required]
        [StringLength(GameSiteMaxLength)]
        [Display(Name = "Game site")]
        public string GameSite { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(0[1-9]|[1-2][0-9]|3[0-1])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "The date must be in this format: dd/mm/yyyy")]
        [Display(Name = "Game release date")]
        public string ReleaseDate { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string CoverImage { get; set; } = null!;

        [Required]
        [Display(Name = "Is the game released?")]
        public bool IsReleased { get; set; }

        public IEnumerable<GameSelectGenreFormModel> Genres { get; set; }

        public HashSet<int> GenreIds { get; set; }
    }
}
