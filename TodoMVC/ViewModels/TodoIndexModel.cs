using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMVC.Models;

namespace TodoMVC.ViewModels {
    public class TodoIndexModel {
        public Todo Todo { get; set; }
        public IEnumerable<Todo> Todos { get; set; }

        public TodoIndexModel(IEnumerable<Todo> todos) {
            Todos = todos;
            Todo = new Todo();
        }

        public TodoIndexModel(IEnumerable<Todo> todos, Todo current)
            : this(todos) {
            Todo = current;
        }
    }
}