using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("WatchLish")]
    public class WatchList
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public virtual ICollection<WatchListProduct> Products { get; set; }
    }
}
