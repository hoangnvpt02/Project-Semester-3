using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("ProductDetailImage")]
    public class ProductDetailImage
    {
        [Key]
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long FileDetailsId { get; set; }
    }
}
