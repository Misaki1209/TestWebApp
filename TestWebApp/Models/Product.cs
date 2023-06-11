using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
    [Required]
    public int UnitsInStock { get; set; }

    [Required] 
    public bool Deleted { get; set; } = false;
    
    public ICollection<ProductCategory>? ProductCategories { get; set; }
}