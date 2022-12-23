namespace NetCore_Backend.Models
{
    public class CommentModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }

        public long ProductId { get; set; }

        public string Content { get; set; }
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
