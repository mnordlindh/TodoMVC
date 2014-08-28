using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMVC.Models {
    public class Todo {
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}