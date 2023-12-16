using System.Collections.Generic;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.services
{
    public interface IProductService
    {
        Product GetProductById(int productId);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
