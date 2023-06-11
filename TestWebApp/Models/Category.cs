using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }

    [Required] 
    public bool Deleted { get; set; } = false;
    public ICollection<ProductCategory>? ProductCategories { get; set; }
}