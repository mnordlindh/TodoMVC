using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;
using TodoMVC.Repositories;

namespace TodoMVC.Controllers
{
    public class TodoController : Controller
    {
        TodoRepository _todos;

        public TodoController() {
            _todos = RepositoryFactory.GetTodoRepository();
        }

        // GET: Todo
        public ActionResult Index()
        {
            var todos = _todos.All();

            return View(todos);
        }
    }
}