using Interview.Web.Models;
using System.Collections.Generic;

namespace Interview.Web.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int productId);
        IEnumerable<Product> GetProductBySku(string sku);
        int Insert(Product product);
        void Update(Product product);
        void Delete(Product product);
        void save();
    }
}
