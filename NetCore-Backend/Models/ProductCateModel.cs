using NetCore_Backend.Data;

namespace NetCore_Backend.Models
{
    public class ProductCateModel
    {
        public long ? Id { get; set; }

        public long ? ProductId { get; set; }

        public long ? CategoryId { get; set; }
        public int ? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
