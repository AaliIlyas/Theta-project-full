using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Theta.Models.Database;
using Theta.Models.RequestModel;
using Theta.Services;

namespace Theta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orders;

        public OrderController(IOrderService orderService)
        {
            _orders = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orders.GetAllOrders();
        }

        [HttpPost]
        public void AddOrder(OrderRequestModel order)
        {
            _orders.AddOrder(order);
        }

        [HttpDelete]
        public void DeleteOrder(int id)
        {
            _orders.DeleteOrder(id);
        }
    }
}
