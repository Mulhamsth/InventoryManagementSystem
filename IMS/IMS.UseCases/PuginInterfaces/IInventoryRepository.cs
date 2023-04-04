using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PuginInterfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
		Task<Inventory> GetInventoryByIdAsync(int InventoryId);
		Task AddInventoryAsync(Inventory inventory);
		Task<bool> ExistsAsync(Inventory inventory);
		Task UpdateInventoryAsync(Inventory inventory);
		Task DeleteInventoryAsync(Inventory inventory);
	}
}
