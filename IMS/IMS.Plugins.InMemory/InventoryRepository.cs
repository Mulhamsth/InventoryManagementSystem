﻿using IMS.CoreBusiness;
using IMS.UseCases.PuginInterfaces;
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
                new Inventory{InventoryId = 4, InventoryName ="Bike Pedels", Quantity = 20, Price = 1}
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

		public Task ExistsAsync(Inventory inventory)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}