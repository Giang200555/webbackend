using LAB3.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB3.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Áo thun đồng phục",  Price = 199000m },
            new Product { Id = 2, Name = "Quần jeans",         Price = 349000m },
            new Product { Id = 3, Name = "Giày thể thao",      Price = 499000m },
        };

        public IActionResult Details()
        {
            return View(_products);
        }
    }
}
