using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("EMP_ID")]
        public int EmpId { get; set; }
        [Column("EMP_CODE")]
        public String Code { get; set; }
        [Column("EMP_NAME")]
        public String Name{ get; set; }
        [Column("EMP_PHONE")]
        public String Phone{ get; set; }
        [Column("EMP_EMAIL")]
        public String Email { get; set; }
        [Column("EMP_POSITION")]
        public String Position { get; set; }

        [Column("EMP_EMP_ID")]
        public int ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Employee Parent { get; set; }
        [Column("DEP_ID")]
        public int DepId { get; set; }
        [ForeignKey("DepId")]
        public virtual Department Department { get; set; }
    }
}
