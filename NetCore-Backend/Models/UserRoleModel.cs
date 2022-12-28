namespace NetCore_Backend.Models
{
    public class UserRoleModel
    {
        public long id { get; set; }
        public string ? AspNetUsersId { get; set; }

        public long? RoleId { get; set; }

        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
