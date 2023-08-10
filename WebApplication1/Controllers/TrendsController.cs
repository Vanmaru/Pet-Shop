using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class TrendsController : Controller
    {
        private readonly IRepository repository;

        public TrendsController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult TrendsPage()
        {
            ViewBag.Kinds = repository.GetKinds();
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 2; i++)
                for (int j = 1; j <= 6; j++)
                    products.AddRange(repository.GetProducts().Where(p => p.CategoryId == i && p.KindId == j).Take(2).ToList());
            return View(products);
        }
    }
}
