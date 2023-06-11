using TestWebApp.Data;
using TestWebApp.IRepository;
using TestWebApp.Models;

namespace TestWebApp.Repository;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private WebContext _context;

    public ProductCategoryRepository(WebContext context)
    {
        _context = context;
    }
    public void AddProductCategory(ProductCategory productCategory)
    {
        try
        {
            var checkPC = _context.ProductCategories.FirstOrDefault(x => x.ProductId == productCategory.ProductId && x.CategoryId == productCategory.CategoryId);
            if (checkPC == null)
            {
                _context.ProductCategories.Add(productCategory);
                _context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProductCategory(ProductCategory productCategory)
    {
        try
        {
            var checkPC = _context.ProductCategories.FirstOrDefault(x => x.ProductId == productCategory.ProductId && x.CategoryId == productCategory.CategoryId);
            if (checkPC != null)
            {
                _context.ProductCategories.Remove(checkPC);
                _context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<ProductCategory> GetProductCategories()
    {
        try
        {
            return _context.ProductCategories.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}