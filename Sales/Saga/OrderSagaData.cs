namespace Sales.Saga
{
	public class OrderSagaData : IContainSagaData
	{
		public Guid Id { get; set; }
		public string? Originator { get; set; }
		public string? OriginalMessageId { get; set; }

		public long OrderId { get; set; }
	}
}
