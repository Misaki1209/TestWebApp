using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.IRepository;

public interface IProductCategoryRepository
{
    public void AddProductCategory(ProductCategory productCategory);
    public void DeleteProductCategory(ProductCategory productCategory);
    public IEnumerable<ProductCategory> GetProductCategories();
}