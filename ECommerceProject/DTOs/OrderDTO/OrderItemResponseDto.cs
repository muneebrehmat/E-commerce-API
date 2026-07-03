namespace ECommerceProject.DTOs.OrderDTO
{
    public class OrderItemResponseDto
    {
        public string ProductName { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
