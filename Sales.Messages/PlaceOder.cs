namespace Sales.Messages
{
	public class PlaceOder :ICommand
	{
		public long OrderId { get; set; }
		public long CustomerId { get; set; }
		public long OrderPrice { get; set; }
	}
}
