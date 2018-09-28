using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [Column("ITE_ID")]
        public int ItemId { get; set; }
        [Column("ITE_Name")]
        public string name { get; set; }
        [Column("ITE_DESCRIPTION")]
        public string Descript { get; set; }
        [Column("ITE_PRICE")]
        public decimal Price { get; set; }
        [Column("ITE_IMAGE")]
        public string Image { get; set; }
    }
}
