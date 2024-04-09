using Inventory.Messages;
using Sales.Messages;

namespace Sales.Saga
{
    public class OrderSaga : Saga<OrderSagaData>,
	    IAmStartedByMessages<PlaceOder>, 
        IHandleMessages<StockReserved>,
    IHandleMessages<StockReservationFailed>
	{ 

	    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderSagaData> mapper)
	    {
		    mapper.ConfigureMapping<PlaceOder>(message => message.OrderId)
			    .ToSaga(sagaData => sagaData.OrderId);

		    mapper.ConfigureMapping<StockReserved >(message => message.OrderId)
			    .ToSaga(sagaData => sagaData.OrderId);

		    mapper.ConfigureMapping<StockReservationFailed>(message => message.OrderId)
			    .ToSaga(sagaData => sagaData.OrderId);
		}

		public async Task Handle(PlaceOder message, IMessageHandlerContext context)
        {

	        Console.WriteLine("I received the place order command ");
	        await context.Send("Inventory", new ReserveStock()
	        {
		        OderId = message.OrderId,
		        ProductId = new Random(Guid.NewGuid().GetHashCode()).Next(1,1000),
		        Quantity = 2
	        });
        }

     

        public Task Handle(StockReserved message, IMessageHandlerContext context)
        {
	        Console.WriteLine($"Stock Reserved for order { message.OrderId} ");
			return Task.CompletedTask;
        }

        public Task Handle(StockReservationFailed message, IMessageHandlerContext context)
        {
			Console.WriteLine($"Stock Reserved for order {message.OrderId} failed because of {message.Reason}");
			return Task.CompletedTask;
		}
	}
}
