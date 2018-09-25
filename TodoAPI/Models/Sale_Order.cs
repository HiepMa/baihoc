using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("Sale_Orders")]
    public class Sale_Order
    {
        [Key]
        [Column("SAL_NUMBER")]
        public int SalNumber { get; set; }
        [Column("SAL_DATE")]
        public DateTime Date { get; set; }
        [Column("SAL_TAX")]
        public float Tax { get; set; }

        [Column("CUS_ID")]
        public int CusId { get; set; }
        [ForeignKey("CusId")]
        public virtual Customer Customer { get; set; }
        [Column("EMP_ID")]
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
    }
}
