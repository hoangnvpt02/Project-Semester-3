using Microsoft.Build.Framework;

namespace NetCore_Backend.Models
{
    public class UserModel
    {
        public long Id { get; set; }
       
        public string Name { get; set; }
       
        public string Email { get; set; }
     
        public string Password { get; set; }
      
        public string Phone { get; set; }
        
        public string Address { get; set; }
        public string IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
