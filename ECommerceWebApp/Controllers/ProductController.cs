using ECommerceWebApp.services;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        var allProducts = _productService.GetAllProducts();
        return View("Index",allProducts);
    }
    

    public IActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    public IActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.AddProduct(product);
            return RedirectToAction("Index","Product");
        }

        
        return View(product);
    }

    public IActionResult Edit(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = "Ürün eklenirken bir hata oluştu. Lütfen tekrar deneyin.";
        return View("Create", product);

        
    }

    public IActionResult Delete(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}

