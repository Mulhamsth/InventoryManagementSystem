using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace IMS.WebApp.Data;

public class InventoryContext : DbContext
{

    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
        
    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Product> Products { get; set; }
}