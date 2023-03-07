using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using ProductList.Models;

namespace ProductList.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext context { get; set; }

        public ProductController(ProductContext ctx) {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add() {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            var Product = context.Products.Find(id);
            return View(Product);
        }

        [HttpGet]
        public IActionResult Detail(int id) {
            ViewBag.Action = "Detail";
            var Product = context.Products.Find(id);
            ViewBag.Category = context.Categories.FirstOrDefault(g => g.CategoryId == Product.CategoryId)?.Name ?? "";
            ViewBag.Vendor = !string.IsNullOrEmpty(Product.Vendor) ? Product.Vendor : "";
            ViewBag.Code = !string.IsNullOrEmpty(Product.Code) ? Product.Code : "";
            ViewBag.Description = !string.IsNullOrEmpty(Product.Description) ? Product.Description : "";
            return View(Product);
        }


        [HttpPost]
        public IActionResult Edit(Product Product,bool detail = false) {

            if(detail) {
                ViewBag.Action = "Edit";
                ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
                return View(Product);
            }
            
            if (ModelState.IsValid) {
                if (Product.ProductId == 0) 
                    context.Products.Add(Product);
                else 
                    context.Products.Update(Product);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            } else {    
                ViewBag.Action = (Product.ProductId == 0) ? "Add": "Edit";
                ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
                return View(Product);
            }
        }

        [HttpPost]
        public IActionResult DetailEdit(Product Product) {
            return RedirectToAction("Edit", "Product", new { id = Product.ProductId });
        }


        [HttpGet]
        public IActionResult Delete(int id) {
            var Product = context.Products.Find(id);
            return View(Product);
        }

        [HttpPost]
        public IActionResult Delete(Product Product) {
            context.Products.Remove(Product);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}