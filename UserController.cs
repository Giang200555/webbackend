using LAB4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LAB4.Controllers
{
    public class UserController : Controller
    {
        private static List<User> _users = new List<User>();

        // Hiển thị danh sách user
        public IActionResult Index()
        {
            return View(_users);
        }

        // GET: hiển thị form Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: xử lý form Add
        [HttpPost]
        public IActionResult Add(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _users.Add(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: hiển thị form Edit, lấy user theo id
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _users.FirstOrDefault(u => u.id == id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: xử lý form Edit
        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existing = _users.FirstOrDefault(u => u.id == model.id);
            if (existing == null)
                return NotFound();

            // Cập nhật các trường
            existing.username = model.username;
            existing.password = model.password;
            existing.email = model.email;
            existing.phone = model.phone;

            return RedirectToAction(nameof(Index));
        }
    }
}
