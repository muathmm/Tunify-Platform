using Microsoft.AspNetCore.Identity;

namespace Tunify_Platform.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? token { get; set; }
        public DateTime createdAt { get; set; }
    }
}
