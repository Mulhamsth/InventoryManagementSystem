using IMS.CoreBusiness;
using IMS.UseCases.PuginInterfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

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
                new Inventory{InventoryId = 2, InventoryName ="Bike Body", Quantity = 10, Price = 15},
                new Inventory{InventoryId = 3, InventoryName ="Bike Wheels", Quantity = 20, Price = 8},
                new Inventory{InventoryId = 4, InventoryName ="Bike Pedels", Quantity = 20, Price = 1},
                new Inventory{InventoryId = 5, InventoryName ="Giant C1285 MTB Sport 26\" Tire", Quantity = 4, Price = 21},
                new Inventory{InventoryId = 5, InventoryName ="Serfas Dual Density Men's Saddle", Quantity = 7, Price = 44.99},
                new Inventory{InventoryId = 5, InventoryName ="Premium Tube Schrader Valve", Quantity = 1, Price = 7.99},
                new Inventory{InventoryId = 5, InventoryName ="Premium Tube Presta Valve", Quantity = 9, Price = 7.99},
            };
        }

		public Task AddInventoryAsync(Inventory inventory)
		{
			if(_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);
            return Task.CompletedTask;
		}


		public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

		public async Task<Inventory> GetInventoryByIdAsync(int InventoryId)
		{
            var inv = _inventories.First(x => x.InventoryId == InventoryId);
            var newInv = new Inventory 
            { 
                InventoryId = inv.InventoryId,
                InventoryName = inv.InventoryName,
                Price = inv.Price,
                Quantity = inv.Quantity,
            };
            return await Task.FromResult(newInv);
		}

		public Task UpdateInventoryAsync(Inventory inventory)
		{
            if (_inventories.Any(x => x.InventoryId != inventory.InventoryId &&
            x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if(inv != null)
            {
                inv.InventoryId = inventory.InventoryId;
                inv.Price= inventory.Price;
                inv.Quantity= inventory.Quantity;
            }

            return Task.CompletedTask;
		}

		Task<bool> IInventoryRepository.ExistsAsync(Inventory inventory)
		{
			throw new NotImplementedException();
		}
	}
}