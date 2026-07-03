namespace ECommerceProject.DTOs.ProductDTO
{
    public class ProductResponseDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

    }
}
