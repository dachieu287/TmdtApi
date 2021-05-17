using Microsoft.AspNetCore.Identity;

namespace Tmdt.Infrastructure.Identity.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
