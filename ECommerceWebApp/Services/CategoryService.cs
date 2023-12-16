public class CategoryService : ICategoryService
{
    private readonly MyDbContext _dbContext;

    public CategoryService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _dbContext.Categories.ToList();
    }

    public Category GetCategoryById(int categoryId)
    {
        return _dbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
    }

    public void AddCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        var existingCategory = _dbContext.Categories.Find(category.Id);

        if (existingCategory != null)
        {
            
            existingCategory.Name = category.Name;

            _dbContext.SaveChanges();
        }
    }

    public void DeleteCategory(int categoryId)
    {
        var category = _dbContext.Categories.Find(categoryId);

        if (category != null)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }
}

