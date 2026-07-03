namespace ECommerceProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
