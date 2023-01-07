namespace NetCore_Backend.Models
{
    public class ProductModel
    {
        public long ? Id { get; set; }
        public long ? CountryId { get; set; }
        public string ? AspNetUsersId { get; set; }
        public Decimal Price { get; set; }
        public Decimal ? PriceAution { get; set; }
        public Decimal ? PriceSale { get; set; }
        public Decimal? PriceAuction { get; set; } 
        public string ? Author { get; set; }
        public string ? Name { get; set; }

        public string ? ManufactureYear { get; set; }
        public string ? Quanlity { get; set; }
        public string ? Description { get; set; }

        public long? FileDetailsId { get; set; }
        public string ? Address { get; set; }
        public int IsActive { get; set; }
        public int ? IsFeature { get; set; }
        public float ? SalePercent { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
