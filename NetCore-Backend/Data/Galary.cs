using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Galary")]
    public class Galary
    {
        [Key]
        public long Id { get; set; }
        public long ? UserId { get; set; }
       
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Authen { get; set; }
        public string Address { get; set; }
        public string Discription { get; set; }
        public int IsActive { get; set; }
        public DateTime CreeateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Dossier> Dossiers { get; set; }
     
        public virtual ICollection<ProductGalary> Products { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
