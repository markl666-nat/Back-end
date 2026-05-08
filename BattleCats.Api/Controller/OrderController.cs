using BattleCats.BusinessLogic.Interface;
using BattleCats.Domains.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleCats.Api.Controller
{
    /// <summary>
    /// Контроллер заказов Cat Base Shop.
    /// 
    /// Все эндпоинты требуют авторизации (атрибут [Authorize] на классе).
    /// GetAll/Update/Delete — только Manager+/Admin (это инструменты управления магазином).
    /// Get(id)/Create — любой авторизованный юзер (свои заказы).
    /// </summary>
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAction _order;

        public OrderController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _order = bl.GetOrderActions();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetAllOrders()
        {
            var orders = _order.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _order.GetOrderItem(id);
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderDto order)
        {
            var status = _order.CreateOrder(order);
            return Ok(status);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Update([FromBody] OrderDto order)
        {
            var status = _order.UpdateOrder(order);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var status = _order.DeleteOrder(id);
            return Ok(status);
        }
    }
}