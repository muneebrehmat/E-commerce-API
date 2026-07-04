using ECommerceProject.Data;
using ECommerceProject.DTOs.OrderDTO;
using ECommerceProject.Interfaces;
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ECommerceProject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateOrderAsync(OrderCreateDto dto, int userId)
        {
            using var Transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var productIds = dto.Items.Select(i => i.ProductId).ToList();
                var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

                foreach(var item in dto.Items)
                {
                    var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                    if (product == null)
                        return false;
                    if (product.Stock < item.Quantity)
                        return false;
                }

                Order order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.UtcNow
                };
                _context.Orders.Add(order);
                foreach (var item in dto.Items)
                {
                    var product = products.First(p => p.Id == item.ProductId);

                    product.Stock -= item.Quantity;

                    OrderItem orderItem = new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        order = order
                    };

                    _context.OrderItems.Add(orderItem);
                }
                await _context.SaveChangesAsync();

                // Commit transaction
                await Transaction.CommitAsync();

                return true;
            }
            catch
            {
                await Transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<OrderResponseDto>> GetMyOrders(int userId)
        {
            var orders = await _context.Orders.AsNoTracking().Where(u => u.UserId == userId).Select(o => new OrderResponseDto
            {
                OrderId = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.OrderItem.Sum(i => i.Quantity * i.Product.Price),

                Items = o.OrderItem.Select(i => new OrderItemResponseDto
                {
                    ProductName = i.Product.ProductName,
                    price = i.Product.Price,
                    Quantity = i.Quantity,
                    TotalPrice = i.Quantity * i.Product.Price
                })
                .ToList()
            })
                .ToListAsync();
            return orders;
        }
    }
}
