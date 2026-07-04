using ECommerceProject.DTOs.ProductDTO;
using ECommerceProject.Interfaces;

namespace ECommerceProject.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository,ILogger<ProductService> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
        public async Task<bool> createProduct(CreateProductDto dto)
        {
            try
            {
                _logger.LogInformation("Creating a new product with name: {ProductName}", dto.ProductName);

                var result = await _productRepository.CreateProductAsync(dto);

                if (result)
                {
                    _logger.LogInformation("Product created successfully with name: {ProductName}", dto.ProductName);
                }
                else
                {
                    _logger.LogWarning("Repository returned false while creating product: {ProductName}", dto.ProductName);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "An error occurred while creating product: {ProductName}",
                    dto.ProductName);

                throw; 
            }
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
