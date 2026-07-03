namespace ECommerceProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }

        public List<OrderItem> OrderItem { get; set; } = new();
        public User user { get; set; }

    }
}
