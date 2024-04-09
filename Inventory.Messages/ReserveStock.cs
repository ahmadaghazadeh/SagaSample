namespace Inventory.Messages;

public class ReserveStock : ICommand
{
	public long OderId { get; set; }
	public long ProductId { get; set; }

	public long Quantity { get; set; }

}