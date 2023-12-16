using Microsoft.AspNetCore.Mvc;
using ECommerceWebApp.services;



public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var allCategories = _categoryService.GetAllCategories();
        return View(allCategories);
    }

    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.AddCategory(category);
            return RedirectToAction("Index", "Category");
        }


        return View(category);
    }

    public IActionResult Edit(int id)
    {
        var category = _categoryService.GetCategoryById(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }


        return View(category);
    }

    public IActionResult Delete(int id)
    {
        var category = _categoryService.GetCategoryById(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _categoryService.DeleteCategory(id);
        return RedirectToAction("Index");
    }
}


