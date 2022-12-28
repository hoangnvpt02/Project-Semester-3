namespace NetCore_Backend.Models
{
    public class WatchListModel
    {
        public long ? Id { get; set; }
        public long ? UserId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
