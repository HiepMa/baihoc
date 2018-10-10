using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("USE_ID")]
        public long id { get; set; }
        [Column("UserName")]
        public string username { get; set; }
        [Column("Password")]
        public string pwd { get; set; }
        [Column("Fullname")]
        public string fullname { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("IsLocked")]
        public bool Ilock { get; set; }
        [Column("IsDeleted")]
        public bool Idelete { get; set; }
        
        
    }
}
