using Microsoft.AspNetCore.Identity;

namespace NetCore_Backend.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string ?Name { get; set; }

        public string ?Address { get; set; }

        public int IsActive { get; set; }
    }
}
