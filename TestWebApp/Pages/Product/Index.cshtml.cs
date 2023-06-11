using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApp.IRepository;
using TestWebApp.Models;

namespace TestWebApp.Pages.Product;

public class Index : PageModel
{
    private IProductRepository _productRepository;
    private IProductCategoryRepository _productCategoryRepository;
    public IEnumerable<Models.Product> Products;
    public ProductCategory ProductCategory { get; set; }
    public Index(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
    {
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
    }
    public void OnGet()
    {
        Products = _productRepository.GetProducts().Where(x => x.Deleted==false);
        return;
    }

    public IActionResult OnPost(ProductCategory productCategory)
    {
        if (productCategory.ProductId != null && productCategory.CategoryId != null)
        {
            _productCategoryRepository.DeleteProductCategory(productCategory);
        }
        return RedirectToPage("Index");
    }
    
}