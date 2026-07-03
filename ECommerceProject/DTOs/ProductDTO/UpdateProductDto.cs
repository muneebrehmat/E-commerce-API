namespace ECommerceProject.DTOs.ProductDTO
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
