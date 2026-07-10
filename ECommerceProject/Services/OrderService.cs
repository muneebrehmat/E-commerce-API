using ECommerceProject.DTOs.OrderDTO;
using ECommerceProject.Interfaces;
using ECommerceProject.Repository;
using System.Security.Claims;

namespace ECommerceProject.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> createOrder(OrderCreateDto dto,ClaimsPrincipal user)
        {
            int userId = int.Parse(
           user.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            return await _orderRepository.CreateOrderAsync(dto, userId);
        }
        public async Task<List<OrderResponseDto>> GetAllOrders(ClaimsPrincipal user)
        {
            var userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var orders = await _orderRepository.GetMyOrdersAsync(userId);
            if(!orders.Any())
            {
                return null;
            }
            return orders;
        }
    }
}
