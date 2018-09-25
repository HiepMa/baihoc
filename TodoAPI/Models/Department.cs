using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [Column("DEP_ID")]
        public int DepId { get; set; }
        [Column("DEP_NAME")]
        public String Name { get; set; }
    }
}
