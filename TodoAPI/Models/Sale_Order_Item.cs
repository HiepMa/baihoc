using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("Sale_Order_Items")]
    public class Sale_Order_Item
    {
        [Key]
        [Column("SALI_ID")]
        public int SaliId { get; set; }
        [Column("SALI_QUANTITY")]
        public int Quantity { get; set; }
        [Column("SALI_PRICE")]
        public decimal Price { get; set; }

        [Column("SALI_NUMBER")]
        public int SalNum { get; set; }
        [ForeignKey("SalNum")]
        public virtual Sale_Order Sale_Order { get; set; }
        [Column("ITE_ID")]
        public int IteNum { get; set; }
        [ForeignKey("IteNum")]
        public virtual Item Item { get; set; }
    }
}
