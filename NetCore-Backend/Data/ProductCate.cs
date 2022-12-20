using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("ProductCate")]
    public class ProductCate
    {
        [Key]
        public long Id { get; set; }
      
        public Product Product { get; set; }
       
        public Category Category { get; set; }
        public int IsActive { get; set; }
        public DateTime ? Created { get; set; }
        public DateTime ? Updated { get; set; }
    }
}
