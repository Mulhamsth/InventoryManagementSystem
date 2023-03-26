using IMS.CoreBusiness;
using IMS.UseCases.PuginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoryRepository() 
        {
            _inventories= new List<Inventory>
            {
                new Inventory{InventoryId = 1, InventoryName ="Bike Seat", Quantity = 10, Price = 2},
                new Inventory{InventoryId = 1, InventoryName ="Bike Body", Quantity = 10, Price = 15},
                new Inventory{InventoryId = 1, InventoryName ="Bike Wheels", Quantity = 20, Price = 8},
                new Inventory{InventoryId = 1, InventoryName ="Bike Pedels", Quantity = 20, Price = 1}
            };
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}