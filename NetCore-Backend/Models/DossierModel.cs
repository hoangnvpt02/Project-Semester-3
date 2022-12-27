namespace NetCore_Backend.Models
{
    public class DossierModel
    {
        public long ? Id { get; set; }
        public long? UserId { get; set; }

        public string? NumberId { get; set; }
        public long GalaryId { get; set; }

        public int IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
