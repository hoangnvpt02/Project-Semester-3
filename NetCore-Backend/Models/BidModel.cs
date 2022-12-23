namespace NetCore_Backend.Models
{
    public class BidModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? GalaryId { get; set; }
        public long? ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime DidTime { get; set; }
        public int IsActive { get; set; }
    }
}
