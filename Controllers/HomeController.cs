using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductList.Models;

namespace ProductList.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext context { get; set; }

        public HomeController(ProductContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var Products = context.Products.Include(m => m.Category)
                .Include(m => m.Warehouse)
                .OrderBy(m => m.ProductName).ToList();
            return View(Products);
        }
    }
}