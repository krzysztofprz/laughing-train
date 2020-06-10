using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBusinessLogic.Dictionary;
using CommonBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Order
        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            var orders = await _orderService.GetOrders(Status.IN_PROGRESS);

            return View(orders);
        }

    }
}