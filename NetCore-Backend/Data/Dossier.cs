using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("Dossier")]
    public class Dossier
    {
        [Key]
        public long Id { get; set; }
        public string ? AspNetUsersId { get; set; }
       
        public string ? NumberId { get; set; }
        public long ? GalaryId { get; set; }
       
        public int IsActive { get; set; }
        public DateTime ? Created { get; set; }
        public DateTime ? Updated { get; set; }
    }
}
