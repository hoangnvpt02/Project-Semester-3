namespace NetCore_Backend.Models
{
    public class ProductGalaryModel
    {
        public long ? Id { get; set; }
        public long ? GalaryId { get; set; }

        public long ? ProductId { get; set; }

        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
