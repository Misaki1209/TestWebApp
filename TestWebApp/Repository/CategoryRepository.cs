using TestWebApp.Data;
using TestWebApp.IRepository;
using TestWebApp.Models;

namespace TestWebApp.Repository;

public class CategoryRepository : ICategoryRepository
{
    private WebContext _context;

    public CategoryRepository(WebContext context)
    {
        _context = context;
    }
    public ICollection<Category> GetCategories()
    {
        try
        {
            return _context.Categories.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public int GetNextId()
    {
        try
        {
            return _context.Categories.OrderByDescending(x => x.CategoryId).First().CategoryId + 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Category? GetCategoryById(int id)
    {
        try
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddCategory(Category category)
    {
        try
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateCategory(Category category)
    {
        try
        {
            var updateCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (updateCategory == null)
                throw new Exception($"Category id {category.CategoryId} is not found.");
            updateCategory.CategoryName = category.CategoryName;
            //updateCategory.ProductCategories = category.ProductCategories;
            _context.Categories.Update(updateCategory);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteCategory(int id)
    {
        try
        {
            var deleteCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (deleteCategory == null)
                throw new Exception($"Category id {id} is not found.");
            if (deleteCategory.Deleted)
                throw new Exception("This category has been deleted");
            deleteCategory.Deleted = true;
            _context.Categories.Update(deleteCategory);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddProduct(Category category)
    {
        try
        {
            var updateCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (updateCategory == null)
                throw new Exception($"Category id {category.CategoryId} is not found.");
            
            updateCategory.ProductCategories = category.ProductCategories;
            _context.Categories.Update(updateCategory);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}