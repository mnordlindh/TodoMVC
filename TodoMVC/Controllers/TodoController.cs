using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;
using TodoMVC.Repositories;
using TodoMVC.ViewModels;

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
            var model = new TodoIndexModel(_todos.All());

            return View(model);
        }

        // POST: /Todo/Create
        public ActionResult Create(Todo todoToCreate) {
            if (!ModelState.IsValid) {
                var model = new TodoIndexModel(_todos.All(), todoToCreate);

                return View("Index", model);
            }

            _todos.Add(todoToCreate);

            return RedirectToAction("Index");
        }

    }
}