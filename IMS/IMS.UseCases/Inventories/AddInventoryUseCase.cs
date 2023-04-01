using IMS.CoreBusiness;
using IMS.UseCases.PuginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
	public class AddInventoryUseCase : IAddInventoryUseCase
	{
		private readonly IInventoryRepository inventoryRepository;
		public AddInventoryUseCase(IInventoryRepository inventoryRepository)
		{
			this.inventoryRepository = inventoryRepository;
		}
		public async Task ExecuteAsync(Inventory inventory)
		{
			if (!await this.inventoryRepository.ExistsAsync(inventory))
				await this.inventoryRepository.AddInventoryAsync(inventory);
		}
	}
}
