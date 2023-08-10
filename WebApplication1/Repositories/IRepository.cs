using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void InsertProduct(/*Animal animal*/Product product);
        void SaveComment();
        void UpdateProduct(int id,/*Animal animal*/Product product);
        void DeleteProduct(int id);
        string GetProductCategory(int categoryId);
        string GetProductKind(int id);
        IEnumerable<Category> GetCategories();
        IEnumerable<Kind> GetKinds();
        int GetKindId(string name);
    }
}
