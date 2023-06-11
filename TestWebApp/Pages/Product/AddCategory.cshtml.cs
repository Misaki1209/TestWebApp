using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApp.Data;
using TestWebApp.IRepository;
using TestWebApp.Models;

namespace TestWebApp.Pages.Product;

public class AddCategory : PageModel
{
    private ICategoryRepository _categoryRepository;
    private IProductRepository _productRepository;
    private IProductCategoryRepository _productCategoryRepository;
    public ICollection<Category> Categories { get; set; }
    public ICollection<Models.Product> Products { get; set; }
    
    public ProductCategory ProductCategory { get; set; }
    public AddCategory(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }
    public void OnGet()
    {
        Categories = _categoryRepository.GetCategories();
        Products = _productRepository.GetProducts();
    }

    public IActionResult OnPost(ProductCategory productCategory)
    {
        var product = _productRepository.GetProductById(productCategory.ProductId);
        var category = _categoryRepository.GetCategoryById(productCategory.CategoryId);
        
        if (product != null && category != null)
        {
            _productCategoryRepository.AddProductCategory(productCategory);
        }
        
        
        return RedirectToPage("Index");
    }
}