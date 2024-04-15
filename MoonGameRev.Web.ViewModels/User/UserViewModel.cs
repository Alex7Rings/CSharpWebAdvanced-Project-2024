namespace MoonGameRev.Web.Areas.Admin.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool IsAdmin { get; set; } 

        public bool IsModerator { get; set; } 
    }
}
