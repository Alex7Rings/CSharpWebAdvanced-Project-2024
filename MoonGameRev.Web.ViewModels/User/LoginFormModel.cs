using System.ComponentModel.DataAnnotations;

namespace MoonGameRev.Web.ViewModels.User
{
    public class LoginFormModel
    {
        [Required]
        [Display(Name = "Email or Username")]
        public string EmailOrUserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
