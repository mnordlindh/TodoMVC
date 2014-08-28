using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMVC.Models;

namespace TodoMVC.Repositories {
    public class TodoRepository : IRepository<Todo, int> {
        TodoContext _context;

        public TodoRepository(TodoContext ctx) {
            _context = ctx;
        }

        public void Add(Todo item) {
            _context.Todos.Add(item);
            _context.SaveChanges();
        }

        public void Remove(Todo item) {
            _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        public Todo Find(int id) {
            return _context.Todos.Find(id);
        }

        public void Edit(Todo item) {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Todo> All() {
            return _context.Todos.ToList();
        }
    }
}