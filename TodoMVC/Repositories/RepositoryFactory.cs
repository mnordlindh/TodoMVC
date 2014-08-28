using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TodoMVC.Models;

namespace TodoMVC.Repositories {
    /// <summary>
    /// This class handles instantiation of the repositories.
    /// </summary>
    public class RepositoryFactory {
        /// <summary>
        /// Wrapper property to get a context instance.
        /// </summary>
        static TodoContext context {
            get { return ContextFactory.GetContext(); }
        }

        /// <summary>
        /// Retrive a todo repository instance.
        /// </summary>
        public static TodoRepository GetTodoRepository() {
            return new TodoRepository(context);
        }

        // More repositories..
    }
}