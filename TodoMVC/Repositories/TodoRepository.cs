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

        /// <summary>
        /// Add a new todo to the repository.
        /// </summary>
        /// <param name="item">The todo to add.</param>
        public void Add(Todo item) {
            _context.Todos.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove a todo from the repository.
        /// </summary>
        /// <param name="item">The todo to remove.</param>
        public void Remove(Todo item) {
            _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
        }

        /// <summary>
        /// Finds a todo based on its id, if no todo is found null is returned.
        /// </summary>
        /// <param name="id">The id of the todo.</param>
        public Todo Find(int id) {
            return _context.Todos.Find(id);
        }

        /// <summary>
        /// Edit a todo in the repository.
        /// </summary>
        /// <param name="item">The edited todo.</param>
        public void Edit(Todo item) {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Get all todos from the repository.
        /// </summary>
        public IEnumerable<Todo> All() {
            return _context.Todos.ToList();
        }
    }
}