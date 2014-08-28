using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;

namespace TodoMVC.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            var db = new TodoContext();

            db.Todos.ToList();

            return View();
        }
    }
}