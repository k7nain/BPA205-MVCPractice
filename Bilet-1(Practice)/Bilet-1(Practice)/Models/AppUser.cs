using Microsoft.AspNetCore.Identity;

namespace Bilet_1_Practice_.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
