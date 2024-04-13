using Microsoft.AspNetCore.Identity;

namespace MoonGameRev.Data.Models
{
    public class AppUser: IdentityUser<Guid>
    {
        public AppUser()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
