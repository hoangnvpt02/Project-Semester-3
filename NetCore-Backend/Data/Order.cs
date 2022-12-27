using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public long ? ProductId { get; set; }
     
        public long ? UserId { get; set; }
       
        public decimal Price { get; set; }
        public int Status { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
