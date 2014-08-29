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
        [HttpPost]
        public ActionResult Create(Todo todoToCreate) {
            if (!ModelState.IsValid) {
                var model = new TodoIndexModel(_todos.All(), todoToCreate);

                return View("Index", model);
            }

            _todos.Add(todoToCreate);

            return RedirectToAction("Index");
        }

        // POST: /Todo/Edit/:id
        [HttpPost]
        public ActionResult Edit(int id, bool isDone) {
            var todo = _todos.Find(id);
            todo.IsDone = isDone;

            _todos.Edit(todo);

            return RedirectToAction("Index");
        }

        // POST: /Todo/Delete/:id
        [HttpPost]
        public ActionResult Delete(int id) {
            var todoToRemove = _todos.Find(id);
            _todos.Remove(todoToRemove);

            return RedirectToAction("Index");
        }
    }
}