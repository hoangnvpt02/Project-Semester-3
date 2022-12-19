using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public long id { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("UsedId")]
        public User User { get; set; }
        public long? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
