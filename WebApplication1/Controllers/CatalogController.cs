using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository repository;
        public CatalogController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult CatalogPage(int category = 1, string kind = "Нашийники", string sort = "За новизною", int pFrom = default, int pTo = default)
        {
            ViewBag.Category = category;
            ViewBag.Kind = kind;
            ViewBag.CurrentSort = sort;
            ViewBag.Sorts = new string[] { "За новизною", "Дешевше", "Дорожче" };
            ViewBag.Kinds = repository.GetKinds();
            int kindId = repository.GetKindId(kind);
            IEnumerable<Product> sorted;
            switch (sort)
            {
                case "За новизною":
                    sorted = repository.GetProducts().Where(p => p.CategoryId == category && p.KindId == kindId).ToList();
                    break;
                case "Дешевше":
                    sorted=repository.GetProducts().Where(p => p.CategoryId == category && p.KindId == kindId).OrderBy(p => p.Price).ToList();
                    break;
                case "Дорожче":
                    sorted=repository.GetProducts().Where(p => p.CategoryId == category && p.KindId == kindId).OrderByDescending(p => p.Price);
                    break;
                default:
                    return View(repository.GetProducts().Where(p => p.CategoryId == category && p.KindId == kindId));
            }
            if (pFrom != default)
            {
                sorted = sorted.Where(p => p.Price >= pFrom);
            }
            if (pTo != default)
            {
                sorted = sorted.Where(p => p.Price <= pTo);
            }
            return View(sorted);
        }
        public IActionResult SearchPage(string searchQuery)
        {
            ViewBag.Kinds = repository.GetKinds();
            return View(repository.GetProducts().Where(p => p.Name.Contains(searchQuery)).ToList());
        }
        public IActionResult DetailPage(int id)
        {
            ViewBag.Kinds=repository.GetKinds();

            var product = repository.GetProducts().First(an => an.ProductId == id);
            DetailViewModel model = new DetailViewModel()
            {
                Product = product,
                ProductCategory = repository.GetProductCategory(product.CategoryId),
                ProductComments = product.Comments
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult DetailPage(int product, string CommentMessage)
        {
            var animal = repository.GetProducts().First(an => an.ProductId == product);
            animal.Comments.Add(new Comment() { CommentMessage = CommentMessage });
            repository.SaveComment();
            return RedirectToAction("CatalogPage");
        }
    }
}