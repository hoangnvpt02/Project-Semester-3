using NetCore_Backend.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Models
{
    public class WatchListProductModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long WatchListId { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
