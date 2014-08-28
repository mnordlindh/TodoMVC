using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoMVC.Models;

namespace TodoMVC.Repositories {
    /// <summary>
    /// This class is a wrapper class that handles the lifetime of the context.
    /// </summary>
    public class ContextFactory {
        /// <summary>
        /// Retrive the current context instance, for each 
        /// request a new instance of the context is created.
        /// </summary>
        public static TodoContext GetContext() {
            var context = HttpContext.Current.Items["_Context"] as TodoContext;

            return context;
        }
    }
}