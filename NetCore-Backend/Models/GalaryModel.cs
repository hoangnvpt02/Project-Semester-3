namespace NetCore_Backend.Models
{
    public class GalaryModel
    {
        public long Id { get; set; }
        public string ? AspNetUsersId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Authen { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int IsActive { get; set; }
        public DateTime CreeateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
