using IMS.CoreBusiness;
using IMS.UseCases.PuginInterfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using IMS.WebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace IMS.WebApp
{
    public class InventoryRepository : IInventoryRepository
    {
        private InventoryContext _Inventories;

        public InventoryRepository(InventoryContext context)
        {
				
	        _Inventories = context;
	        /*_Inventories.Products.Add(
		        new Product()
		        {
			        Name = "Bike",
			        requirements = _Inventories.Inventories.ToList(),
			        Price = 2000
		        });*/
	        /*_Inventories.Inventories.AddRange(

		        new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
		        new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 15 },
		        new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
		        new Inventory { InventoryId = 4, InventoryName = "Bike Pedels", Quantity = 20, Price = 1 },
		        new Inventory
			        { InventoryId = 5, InventoryName = "Giant C1285 MTB Sport 26\" Tire", Quantity = 4, Price = 21 },
		        new Inventory
		        {
			        InventoryId = 6, InventoryName = "Serfas Dual Density Men's Saddle", Quantity = 7, Price = 44.99
		        },
		        new Inventory
			        { InventoryId = 7, InventoryName = "Premium Tube Schrader Valve", Quantity = 1, Price = 7.99 },
		        new Inventory
			        { InventoryId = 8, InventoryName = "Premium Tube Presta Valve", Quantity = 9, Price = 7.99 }

	        );
		        _Inventories.SaveChangesAsync();*/

        }

		public Task AddInventoryAsync(Inventory inventory)
		{
				if(_Inventories.Inventories.Any(x => x.InventoryName == inventory.InventoryName))
					return Task.CompletedTask;

				var maxId = _Inventories.Inventories.Max(x => x.InventoryId);
				inventory.InventoryId = maxId + 1;

				_Inventories.Inventories.Add(inventory);
				_Inventories.SaveChanges();
				return Task.CompletedTask;
		}

		public Task DeleteInventoryAsync(Inventory inventory)
		{
			if(inventory != null)
                _Inventories.Inventories.Remove(inventory);
			_Inventories.SaveChanges();
            return Task.CompletedTask;
		}

		public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                return await Task.FromResult(_Inventories.Inventories);
            return _Inventories.Inventories.Where(x => x.InventoryName.Contains(name));
        }

		public async Task<Inventory> GetInventoryByIdAsync(int InventoryId)
		{
            var inv = _Inventories.Inventories.First(x => x.InventoryId == InventoryId);
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
            if (_Inventories.Inventories.Any(x => x.InventoryId != inventory.InventoryId &&
            x.InventoryName.Equals(inventory.InventoryName)))
                return Task.CompletedTask;

            var inv = _Inventories.Inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if(inv != null)
            {
                inv.InventoryId = inventory.InventoryId;
                inv.Price= inventory.Price;
                inv.Quantity= inventory.Quantity;
            }
			_Inventories.SaveChanges();
            return Task.CompletedTask;
		}

		Task<bool> IInventoryRepository.ExistsAsync(Inventory inventory)
		{
			throw new NotImplementedException();
		}
	}
}