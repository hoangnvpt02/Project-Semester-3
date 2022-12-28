namespace NetCore_Backend.Models
{
    public class OrderModel
    {
        public long ? Id { get; set; }
        public long ? ProductId { get; set; }

        public string ? AspNetUsersId { get; set; }

        public decimal Price { get; set; }
        public int Status { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
