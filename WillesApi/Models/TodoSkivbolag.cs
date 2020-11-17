using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItemSkivbolag
    {
        [Key]
        public int Skivbolag_ID { get; set; }
        public string Namn { get; set; }
    }
}