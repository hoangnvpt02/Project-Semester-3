namespace NetCore_Backend.Models
{
    public class ProductModel
    {
        public long ? Id { get; set; }
        public long ? CountryId { get; set; }
        public long ? UserId { get; set; }
        public Decimal Price { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }

        public string ManufactureYear { get; set; }
        public string Quanlity { get; set; }
        public string Discription { get; set; }

        public long? FileDetailsId { get; set; }
        public string Address { get; set; }
        public int IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
