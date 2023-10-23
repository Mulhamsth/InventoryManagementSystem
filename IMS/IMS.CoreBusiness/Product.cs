using System.ComponentModel.DataAnnotations;
namespace IMS.CoreBusiness;

public class Product
{
    [Required]
    [Key]
    [StringLength(150)]
    public string Name { get; set; }
    
    public ICollection<Inventory> requirements { get; set; }
    public double Price { get; set; } 
}