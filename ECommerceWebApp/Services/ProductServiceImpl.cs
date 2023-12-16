using System.Collections.Generic;
using System.Linq;
using ECommerceWebApp.Models;
using ECommerceWebApp.services;

public class ProductServiceImpl : IProductService
{
    private readonly MyDbContext _dbContext;

    public ProductServiceImpl(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Product GetProductById(int productId)
    {
        return _dbContext.Products.FirstOrDefault(p => p.Id == productId);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _dbContext.Products.ToList();
    }

    public void AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = _dbContext.Products.Find(product.Id);

        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            _dbContext.SaveChanges();
        }
    }

    public void DeleteProduct(int productId)
    {
        var product = _dbContext.Products.Find(productId);

        if (product != null)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
