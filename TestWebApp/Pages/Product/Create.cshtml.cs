using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApp.IRepository;
using TestWebApp.Models;

namespace TestWebApp.Pages.Product;

public class Create : PageModel
{
    private ICategoryRepository _categoryRepository;
    private IProductRepository _productRepository;
    public Models.Product Product { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Category> SelectedCategories { get; set; }
    public int ProductId { get; set; }

    public Create(ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }
    
    public void OnGet()
    {
        ProductId = _productRepository.GetNextId();
        Categories = _categoryRepository.GetCategories();
    }

    public IActionResult OnPost(Models.Product product)
    {
        _productRepository.AddProduct(product);
        return RedirectToPage("Index");
    }
}