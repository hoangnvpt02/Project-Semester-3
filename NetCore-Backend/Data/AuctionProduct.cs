using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("AuctionProduct")]
    public class AuctionProduct
    {
        [Key]
        public long Id { get; set; }
        public string ? AspNetUsersId { get; set; }
        public Decimal PriceStart { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Quanlity { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public long? FileDetailsId { get; set; }
        [ForeignKey("FileDetailsId")]
        public DateTime ? Created { get; set; }
        public DateTime ? Updated { get; set; }

      
    }
}
