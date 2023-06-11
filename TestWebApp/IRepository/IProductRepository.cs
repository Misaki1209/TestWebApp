using TestWebApp.Models;

namespace TestWebApp.IRepository;

public interface IProductRepository
{
    public ICollection<Product> GetProducts();
    public int GetNextId();
    public Product? GetProductById(int id);
    public void AddProduct(Product product);
    public void UpdateProduct(Product product);
    public void DeleteProduct(int id);
    public ICollection<Product> GetProductsByName(string name);
    public void AddCategory(Product product);
}