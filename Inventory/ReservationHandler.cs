using Inventory.Messages;

namespace Inventory
{
	public class ReservationHandler : IHandleMessages<ReserveStock>
	{
		public async Task Handle(ReserveStock message, IMessageHandlerContext context)
		{
			if (message.ProductId % 2 == 0)
			{
				Console.WriteLine("Stock Reserved !");
				await context.Publish(new StockReserved()
				{
					OrderId = message.OderId,
					ReservationCode = Guid.NewGuid().ToString().Replace("-",""),
				});
			}
			else
			{
				Console.WriteLine("Stock Reservation Failed !");
				await context.Publish(new StockReservationFailed()
				{
					OrderId = message.OderId,
					Reason = " Because I'm too lazy to reserve the stock ",
				});
			}
		}
	}
}
