using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<Galary> Galarys { get; set; }
        public virtual ICollection<Dossier> Dossiers { get; set; }
    }
}
