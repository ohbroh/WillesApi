using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        [Key]
        public int Artist_ID { get; set; }
        public string Namn_Artist { get; set; }
        public int Lot_ID { get; set; }
        public int Skivbolag { get; set; }
    }
}