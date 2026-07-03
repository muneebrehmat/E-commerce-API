using ECommerceProject.DTOs.ProductDTO;
using ECommerceProject.Interfaces;

namespace ECommerceProject.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> createProduct(CreateProductDto dto)
        {
            var result = await _productRepository.CreateProductAsync(dto);
            return result;
        }
        public async Task<List<ProductResponseDto>> GetAllProduct()
        {
            return await _productRepository.GetAllProductAsync();
        }
        public async Task<ProductResponseDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if(product==null)
            {
                return null;

            }
            else
            {
                return product;
            }
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _productRepository.DeleteProductAsync(id);
            if(!result)
            {
                return false;
            }
            return true;
        }
    }
}
