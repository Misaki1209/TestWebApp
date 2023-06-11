using TestWebApp.Models;

namespace TestWebApp.IRepository;

public interface ICategoryRepository
{
    public ICollection<Category> GetCategories();
    public int GetNextId();
    public Category? GetCategoryById(int id);
    public void AddCategory(Category category);
    public void UpdateCategory(Category category);
    public void DeleteCategory(int id);
    public void AddProduct(Category category);
}