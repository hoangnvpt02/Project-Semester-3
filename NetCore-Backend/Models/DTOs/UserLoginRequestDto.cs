using Microsoft.Build.Framework;

namespace NetCore_Backend.Models.DTOs
{
    public class UserLoginRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
