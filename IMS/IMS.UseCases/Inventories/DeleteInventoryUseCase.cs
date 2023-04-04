using IMS.CoreBusiness;
using IMS.UseCases.PuginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories.Interfaces
{
	public class DeleteInventoryUseCase : IDeleteInventoryUseCase
	{
		private readonly IInventoryRepository InventoryRepository;
		public DeleteInventoryUseCase(IInventoryRepository InventoryRepository)
		{
			this.InventoryRepository = InventoryRepository;
		}
		public async Task ExecuteAsync(Inventory inventory)
		{
			await this.InventoryRepository.DeleteInventoryAsync(inventory);
		}
	}
}
