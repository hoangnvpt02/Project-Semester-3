using Microsoft.Build.Framework;

namespace NetCore_Backend.Models.DTOs
{
    public class UserLoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
