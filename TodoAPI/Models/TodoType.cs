using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("TodoTypes")]
    public class TodoType
    {
        [Key]
        public long TYPE_ID { get; set; }
        public string Name { get; set; }
        //public List<TodoItem> items { get; set; }
}
}
