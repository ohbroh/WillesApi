using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItemLot
    {
        [Key]
        public int Lot_ID { get; set; }
        public string Namn_Lot { get; set; }
        public int Artist_ID { get; set; }
        public int Spelningar { get; set; }
        public int Skivbolag { get; set; }

    }
}