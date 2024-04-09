namespace Inventory.Messages;

public class StockReservationFailed : IEvent  
{
	public long OrderId { get; set; }
	public string Reason { get; set; }

}