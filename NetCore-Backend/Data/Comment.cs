using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        public string ? AspNetUsersId { get; set; }
       
        public long ? ProductId { get; set; }
        
        public string Content { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
