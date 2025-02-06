using Microsoft.AspNetCore.Identity;

namespace SportTestAPI.Database
{
    public class User:IdentityUser
    {
        public string? Initials { get; set; }
    }
}
