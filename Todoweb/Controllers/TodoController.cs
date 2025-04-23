using Microsoft.AspNetCore.Mvc;
using LAB2.Models;
using System.Collections.Generic;
using System.Linq;

namespace LAB2.Controllers
{
    public class TodoController : Controller
    {
        // Tạm thời dùng dữ liệu tĩnh
        private static List<TodoItem> todoList = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Ôn tập HTML"},
            new TodoItem { Id = 2, Title = "Ôn tập CSS"},
            new TodoItem { Id = 3, Title = "Ôn tập Bootstrap"},
        };

        private static int nextId = 4;

        public IActionResult Index()
        {
            return View(todoList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TodoItem item)
        {
            item.Id = nextId++;
            todoList.Add(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem updatedItem)
        {
            var item = todoList.FirstOrDefault(x => x.Id == updatedItem.Id);
            if (item != null)
            {
                item.Title = updatedItem.Title;
            }
            return RedirectToAction("Index");
        }
    }
}
