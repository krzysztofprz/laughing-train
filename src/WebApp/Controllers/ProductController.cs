using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBusinessLogic.Dictionary;
using CommonBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IOrderService _orderService;

        public ProductController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Product
        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            var orders = await _orderService.GetOrders(Status.IN_PROGRESS);

            var products = orders.Select(x => x.Lines)
                .SelectMany(x => x)
                .OrderByDescending(x => x.Quantity)
                .Take(5);            

            return View(products);
        }

        // GET: Product/Update/5
        [HttpGet]
        [Route("Product/Edit/{productId}")]
        public async Task<ActionResult> EditAsync(string productId)
        {
            var newQuantity = 25;
            var result = await _orderService.Update(productId, newQuantity);

            TempData["UpdateMessage"] = result;

            return RedirectToAction("Index");
        }
    }
}