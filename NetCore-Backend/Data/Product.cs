using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public long CountryId { get; set; }
        public long UserId { get; set; }
        public Decimal Price { get; set; }
        public string Author { get; set; }
        public string ManufactureYear { get; set; }
        public string Quanlity { get; set; }
        public string Discription { get; set; }
        public string Address { get; set; }
       
        public long ? FileDetailsId { get; set; }
        public int IsActive { get; set; }
        public DateTime ? Created { get; set; }
        public DateTime ? Updated { get; set; }
        public virtual ICollection<ProductCate> Cate { get; set; }
        public virtual ICollection<WatchListProduct> WatchLists { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
      
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<ProductGalary> Galary { get; set; }
    }
}
