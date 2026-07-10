using ECommerceProject.Data;
using ECommerceProject.DTOs.ProductDTO;
using ECommerceProject.Interfaces;
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ApplicationDbContext context,ILogger<ProductRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<bool> CreateProductAsync(CreateProductDto productDto)
        {
            try
            {
                bool categoryExists = await _context.Categories
                    .AnyAsync(c => c.Id == productDto.CategoryId);

                if (!categoryExists)
                {
                    _logger.LogWarning("Category with Id {CategoryId} does not exist.", productDto.CategoryId);
                    return false;
                }

                _logger.LogInformation("Category exists. Creating product.");

                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    Price = productDto.Price,
                    Stock = productDto.Stock,
                    CategoryId = productDto.CategoryId
                };

                _context.Products.Add(product);

                _logger.LogInformation("Saving new product to the database.");

                await _context.SaveChangesAsync();

                _logger.LogInformation("Product saved successfully.");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new product.");
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductResponseDto>> GetAllProductAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryName = p.category.CategoryName
                })
                .ToListAsync();
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var existingProduct = await _context.Products
                .Include(p => p.category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            return new ProductResponseDto
            {
                Id = existingProduct.Id,
                ProductName = existingProduct.ProductName,
                Price = existingProduct.Price,
                Stock = existingProduct.Stock,
                CategoryName = existingProduct.category.CategoryName
            };
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto product)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct == null)
                return false;

            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == product.CategoryId);
            if (existingCategory == null)
                return false;

            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
