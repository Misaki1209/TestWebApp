using Microsoft.EntityFrameworkCore;
using TestWebApp.Data;
using TestWebApp.IRepository;
using TestWebApp.Models;

namespace TestWebApp.Repository;

public class ProductRepository : IProductRepository
{
    private WebContext _context;

    public ProductRepository(WebContext context)
    {
        _context = context;
    }
    public ICollection<Product> GetProducts()
    {
        try
        {
            return _context.Products.Include(p => p.ProductCategories)!.ThenInclude(pc => pc.Category).ToList();
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
            return _context.Products.OrderByDescending(x => x.ProductId).First().ProductId + 1;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product? GetProductById(int id)
    {
        try
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddProduct(Product product)
    {
        try
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateProduct(Product product)
    {
        try
        {
            var updateProduct = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (updateProduct == null)
                throw new Exception($"Product id {product.ProductId} is not found.");
            updateProduct.ProductName = product.ProductName;
            updateProduct.UnitPrice = product.UnitPrice;
            updateProduct.UnitsInStock = product.UnitsInStock;
            //updateProduct.ProductCategories = product.ProductCategories;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProduct(int id)
    {
        try
        {
            var deleteProduct = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (deleteProduct == null)
                throw new Exception($"Product id {id} is not found.");
            if (deleteProduct.Deleted)
                throw new Exception("This product has been deleted");
            deleteProduct.Deleted = true;
            _context.Products.Update(deleteProduct);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ICollection<Product> GetProductsByName(string name)
    {
        try
        {
            return _context.Products.Where(x => x.ProductName.ToUpper().Contains(name.ToUpper())).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddCategory(Product product)
    {
        try
        {
            var updateProduct = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (updateProduct == null)
                throw new Exception($"Product id {product.ProductId} is not found.");
            updateProduct.ProductCategories = product.ProductCategories;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}