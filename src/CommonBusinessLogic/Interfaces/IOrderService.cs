using CommonBusinessLogic.Dictionary;
using CommonBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonBusinessLogic.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Get list of orders for a given status
        /// </summary>
        /// <param name="status">Status used for orders filtering</param>
        /// <returns>Returns list of orders for a given status</returns>
        Task<IEnumerable<Content>> GetOrders(Status status);

        /// <summary>
        /// Updates product quantity for a specified product
        /// </summary>
        /// <param name="productId">Product ID</param>
        /// <param name="quantity">Quantity of a product</param>
        /// <returns>Returns information about update request</returns>
        Task<string> Update(string productId, int quantity);
    }
}
