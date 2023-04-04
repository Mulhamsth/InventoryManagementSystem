using IMS.CoreBusiness;

namespace IMS.UseCases.Inventories.Interfaces
{
	public interface IDeleteInventoryUseCase
	{
		Task ExecuteAsync(Inventory inventory);
	}
}