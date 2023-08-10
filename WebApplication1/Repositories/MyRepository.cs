using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MyRepository : IRepository
    {
        private MyDbContext context;
        public MyRepository(MyDbContext _context)
        {
            context = _context;
        }

        public void SaveComment()
        {
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var productInDb = context.Products.SingleOrDefault(a => a.ProductId == id);
            context.Products.Remove(productInDb);
            context.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.Include(anm => anm.Comments);
        }

        public Product GetProductById(int id)
        {
            return GetProducts().Where(an => an.ProductId == id) as Product;
        }

        public string GetProductCategory(int id)
        {
            return (context.Categories.First(cat => cat.Id == id) as Category).Name;
        }
        public string GetProductKind(int id)
        {
            return (context.Kinds.First(cat => cat.Id == id) as Kind).Name;
        }

        public void InsertProduct(Product product)
        {
            product.ImgUrl = "/images/Animals/" + product.ImgUrl;
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(int id, Product product)
        {
            var productInDb = context.Products.SingleOrDefault(a => a.ProductId == id);
            productInDb.Name = product.Name;
            productInDb.Price = product.Price;
            productInDb.ImgUrl = "/images/Animals/" + product.ImgUrl;
            productInDb.Material = product.Material;
            productInDb.Description = product.Description;
            productInDb.CategoryId = product.CategoryId;
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories;
        }
        public IEnumerable<Kind> GetKinds()
        {
            return context.Kinds;
        }
        public int GetKindId(string name)
        {
            return GetKinds()
                .Where(an => an.Name == name)
                .Select(an => an.Id)
                .FirstOrDefault();
        }
    }
}
