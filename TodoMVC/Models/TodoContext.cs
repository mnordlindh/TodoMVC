using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoMVC.Models {
    /// <summary>
    /// Derived context.
    /// </summary>
    public class TodoContext : DbContext {
        // Your context has been configured to use a 'TodoContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TodoMVC.Models.TodoContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TodoContext' 
        // connection string in the application configuration file.
        public TodoContext()
            : base("name=TodoContext"){
            // Database strategy
            Database.SetInitializer<TodoContext>(new TodoDbInit());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Todo> Todos { get; set; }


        // If you want to try or need to (some use cases) use fluent API this is the place!
        // Reference: http://blogs.msdn.com/b/adonet/archive/2010/12/14/ef-feature-ctp5-fluent-api-samples.aspx
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// Derived database strategy
    /// </summary>
    class TodoDbInit : DropCreateDatabaseAlways<TodoContext> {
        protected override void Seed(TodoContext context) {
            base.Seed(context);

            // Seed your data here!

            Todo todo = new Todo() {
                Text = "A test todo.",
                IsDone = false,
                TimeCreated = DateTime.Now
            };
            Todo doneTodo = new Todo() {
                Text = "Something I did yesterday!.",
                IsDone = true,
                TimeCreated = DateTime.Now - TimeSpan.FromDays(1)
            };
            Todo longTodo = new Todo() {
                Text = "A very very long todo text that never seems to end, maybe this will overflow?",
                IsDone = false,
                TimeCreated = DateTime.Now
            };

            context.Todos.Add(todo);
            context.Todos.Add(doneTodo);
            context.Todos.Add(longTodo);

            context.SaveChanges();
        }
    }
}