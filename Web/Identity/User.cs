using Microsoft.AspNetCore.Identity;

namespace Web.Identity
{
    public class User : IdentityUser
    {
        public string name { get; set; }
        public string surname { get; set; }

    }
}
