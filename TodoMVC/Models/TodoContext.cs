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
        public TodoContext()
            : base("DefaultConnection") {
            // Database strategy
                Database.SetInitializer<TodoContext>(new SocialMediaDbInit());
        }

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
    class SocialMediaDbInit : DropCreateDatabaseIfModelChanges<TodoContext> {
        protected override void Seed(TodoContext context) {
            base.Seed(context);

            // Seed your data here!
        }
    }
}