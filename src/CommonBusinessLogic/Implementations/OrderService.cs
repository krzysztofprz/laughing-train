using CommonBusinessLogic.Dictionary;
using CommonBusinessLogic.Interfaces;
using CommonBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonBusinessLogic.Implementations
{
    public class OrderService : IOrderService
    {
        public async Task<IEnumerable<Content>> GetOrders(Status status)
        {
            var url = @"https://api-dev.channelengine.net/api/v2/orders?statuses=" + status + "&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";

            using (var client = new HttpClient())
            {
                var response = client.GetStreamAsync(url);

                var parsed = await JsonSerializer.DeserializeAsync<Rootobject>(await response);

                var orders = new List<Content>();

                foreach (var order in parsed.Content)
                {
                    orders.Add(order);
                }

                return orders;
            }
        }

        public async Task<string> Update(string productId, int quantity)
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    MerchantProductNo = productId,
                    Stock = quantity
                }
            };

            var serialized = JsonSerializer.Serialize(products);

            using (var client = new HttpClient())
            {
                var payload = new StringContent(serialized, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri("https://api-dev.channelengine.net/api/v2/offer?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322"),
                    Content = payload
                };

                var response = await client.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
