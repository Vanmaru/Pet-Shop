using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository repository;
        public AdminController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult AdminPage(int id = 1)
        {
            ViewBag.Kinds = repository.GetKinds();
            ViewBag.CurrentCategory = repository.GetProductCategory(id);
            ViewBag.Categories = repository.GetCategories();
            return View(repository.GetProducts().Where(anm => anm.CategoryId == id));
        }

        public IActionResult DeleteProduct(int id)
        {
            repository.DeleteProduct(id);
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            ViewBag.Kinds = repository.GetKinds();
            var currentProduct = repository.GetProducts().First(an => an.ProductId == id);
            return View(currentProduct);
        }
        
        [HttpPost]
        public IActionResult EditProduct(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateProduct(id, product);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return EditProduct(id);
            }

        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Kinds=repository.GetKinds();
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ViewBag.Kinds=repository.GetKinds();
            if (ModelState.IsValid)
            {
                repository.InsertProduct(product);
                return RedirectToAction("AdminPage");
            }
            else
            {
                return View("AddProduct");
            }

        }
    }
}