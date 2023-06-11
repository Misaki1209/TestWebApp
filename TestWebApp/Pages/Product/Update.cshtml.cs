using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApp.IRepository;
using TestWebApp.Models;

namespace TestWebApp.Pages.Product;

public class Update : PageModel
{
    
    private ICategoryRepository _categoryRepository;
    private IProductRepository _productRepository;
    public Models.Product Product { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Category> SelectedCategories { get; set; }
    public int ProductId { get; set; }

    public Update(ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }
    
    public void OnGet(int id)
    {
        Product = _productRepository.GetProductById(id);
        Categories = _categoryRepository.GetCategories();
    }

    public IActionResult OnPostUpdate(Models.Product product)
    {
        _productRepository.UpdateProduct(product);
        return RedirectToPage("Index");
    }
    
    public IActionResult OnPostDelete(Models.Product product)
    {
        _productRepository.DeleteProduct(product.ProductId);
        return RedirectToPage("Index");
    }
}