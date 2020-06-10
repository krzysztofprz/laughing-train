using CommonBusinessLogic.Implementations;
using CommonBusinessLogic.Interfaces;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var service = new OrderService() as IOrderService;

            var ca = new ConsoleApp(service);
            ca.Execute().GetAwaiter().GetResult();
        }
    }
}
