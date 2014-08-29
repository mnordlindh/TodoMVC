using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoMVC.Models {
    public class Todo {
        [Key]
        public int Id { get; set; }
        [StringLength(120, MinimumLength=4)]
        [Required]
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public DateTime TimeCreated { get; set; }

        public Todo() {
            IsDone = false;
            TimeCreated = DateTime.Now;
        }
    }
}