﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_Backend.Data
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public long id { get; set; }
        public string ? AspNetUsersId { get; set; }
       
        public long? RoleId { get; set; }
       
        public int IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
