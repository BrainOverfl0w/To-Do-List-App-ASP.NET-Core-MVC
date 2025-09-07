using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> _tasks = new List<TodoItem>();

        public IActionResult Index()
        {
            return View(_tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoItem task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _tasks.Count + 1;
                _tasks.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public IActionResult Complete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                task.IsComplete = true;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                _tasks.Remove(task);
            return RedirectToAction(nameof(Index));
        }
    }
}
