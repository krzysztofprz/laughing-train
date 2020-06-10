using CommonBusinessLogic.Dictionary;
using CommonBusinessLogic.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ConsoleApp
    {
        private readonly IOrderService _orderService;

        public ConsoleApp(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Execute()
        {
            var orders = await _orderService.GetOrders(Status.IN_PROGRESS);

            Console.WriteLine("Printing out all orders: ");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id} - ChannelOrderNo: {order.ChannelOrderNo}");
            }

            Console.WriteLine("Orders printed out");
            Console.WriteLine();

            Console.WriteLine("Printing out top 5 orders in the descending order: ");

            var products = orders.Select(x => x.Lines)
                .SelectMany(x => x)
                .ToArray();

            var topSoldProducts = products
                .OrderByDescending(x => x.Quantity)
                .Take(5);

            foreach (var topSoldProduct in topSoldProducts)
            {
                Console.WriteLine($"Product name: {topSoldProduct.MerchantProductNo} - EAN: {topSoldProduct.Gtin} - Quantity: {topSoldProduct.Quantity}");
            }

            Console.WriteLine("Top 5 ordered orders printed out");
            Console.WriteLine();

            Console.WriteLine("Updating the first product stock of the first order to 25");

            var updateMessage = await _orderService.Update("001201-L", 25);

            Console.WriteLine($"Update message: {updateMessage}");
        }
    }
}
