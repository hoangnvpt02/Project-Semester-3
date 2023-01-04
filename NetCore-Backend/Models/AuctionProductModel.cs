using NetCore_Backend.Data;

namespace NetCore_Backend.Models
{
    public class AuctionProductModel
    {
        public long Id { get; set; }
        public string? AspNetUsersId { get; set; }
        public Decimal PriceStart { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Quanlity { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public long? FileDetailsId { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

    }
}
