namespace Inventory.Messages
{
	public class StockReserved : IEvent
	{
		public long OrderId { get; set; }
		public string ReservationCode { get; set; }

	}
}
