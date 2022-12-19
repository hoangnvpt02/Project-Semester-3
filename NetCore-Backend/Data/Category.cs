using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public DateTime ? Created { get; set; }
        public DateTime ? Updated { get; set; }
        public virtual ICollection<ProductCate> Cate { get; set; }
    }
}
