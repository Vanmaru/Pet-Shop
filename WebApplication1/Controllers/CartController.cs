using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository repository;

        public CartController(IRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult CartPage()
        {
            ViewBag.Kinds = repository.GetKinds();
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        public IActionResult AddToCart(string name, int category, int kind)
        {
            var product = repository.GetProducts().SingleOrDefault(p => p.Name == name && p.CategoryId == category && p.KindId == kind);
            var c = repository.GetProductCategory(category);
            var k = repository.GetProductKind(kind);
            if (product != null)
            {
                var cartItems = GetCartItems();

                var cartItem = cartItems.SingleOrDefault(c => c.Product.Name == name);

                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    cartItems.Add(new CartItem { ProductId = product.ProductId, Product = product, Category = c, Kind = k, Quantity = 1 });
                }

                SaveCartItems(cartItems);
            }

            return RedirectToAction(nameof(CartPage));
        }
        public IActionResult UpdateCart(int id, int quantity)
        {
            List<CartItem> cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                if (item.ProductId == id)
                {
                    item.Quantity = quantity;
                    break;
                }
            }
            SaveCartItems(cartItems);
            return RedirectToAction(nameof(CartPage));
        }
        public IActionResult RemoveFromCart(int id)
        {
            var cartItems = GetCartItems();
            var cartItem = cartItems.SingleOrDefault(c => c.ProductId == id);
            if (cartItem != null)
            {
                cartItems.Remove(cartItem);
                SaveCartItems(cartItems);
            }

            return RedirectToAction(nameof(CartPage));
        }

        private List<CartItem> GetCartItems()
        {
            var sessionData = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(sessionData))
            {
                return new List<CartItem>();
            }

            return JsonConvert.DeserializeObject<List<CartItem>>(sessionData);
        }

        private void SaveCartItems(List<CartItem> cartItems)
        {
            var sessionData = JsonConvert.SerializeObject(cartItems);
            HttpContext.Session.SetString("Cart", sessionData);
        }
    }
}
