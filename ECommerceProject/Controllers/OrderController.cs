using ECommerceProject.DTOs.OrderDTO;
using ECommerceProject.Models;
using ECommerceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
       
        [HttpPost]
        public async Task<IActionResult> createOrder(OrderCreateDto dto)
        {
            var result = await _orderService.createOrder(dto, User);
            if(!result)
            {
                return BadRequest("Order could not be created.");

            }
            return Ok("Order created successfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllOrders(User);
            if (orders == null)
            {
                return NotFound(new
                {
                    Message = "No orders found. Order not created yet."
                });
            }

            return Ok(orders);
        }

    }
}
