using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(0,100)]
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
