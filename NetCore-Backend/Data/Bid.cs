using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Bid")]
    public class Bid
    {
        [Key]
        public long Id { get; set; }
        public string ? AspNetUsersId { get; set; }
        public long ? GalaryId { get; set; }
        public long ? ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime DidTime { get; set; }
        public int IsActive { get; set; }
    }
}
