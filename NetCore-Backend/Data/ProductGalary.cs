using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("ProductGalary")]
    public class ProductGalary
    {
        [Key]
        public long Id { get; set; }
        public long ? GalaryId { get; set; }
       
        public long ? ProductId { get; set; }
       
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
