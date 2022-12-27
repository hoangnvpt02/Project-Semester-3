using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("WatchListProduct")]
    public class WatchListProduct
    {
        [Key]
        public long Id { get; set; }
        public long ? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public long ? WatchListId { get; set; }
        [ForeignKey("WatchListId")]
        public WatchList WatchList { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
