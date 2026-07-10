using ECommerceProject.DTOs.OrderDTO;

namespace ECommerceProject.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrderAsync(OrderCreateDto dto,int userId);

        Task<List<OrderResponseDto>> GetMyOrdersAsync(int userId);

    }
}
