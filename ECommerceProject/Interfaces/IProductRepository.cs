using ECommerceProject.DTOs.ProductDTO;

namespace ECommerceProject.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(CreateProductDto product);
        Task<ProductResponseDto> GetProductByIdAsync(int id);
        Task<List<ProductResponseDto>> GetAllProductAsync();
        Task<bool> DeleteProductAsync(int id);
        Task<bool> UpdateProductAsync(int id, UpdateProductDto product);
       
    }
}
