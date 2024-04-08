using System.ComponentModel.DataAnnotations;
using static MoonGameRev.Common.EntityValidationConstants.Journalist;

namespace MoonGameRev.Web.ViewModels.Journalist
{
    public class BecomeJournalistFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength), MinLength(PhoneNumberMinLength)]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
