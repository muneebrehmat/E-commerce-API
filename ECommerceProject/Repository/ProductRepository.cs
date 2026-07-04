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
        public async Task<bool> CreateProductAsync(CreateProductDto product)
        {
            try
            {
                var categoryExist = await _context.Categories.AnyAsync(c => c.Id == product.CategoryId);
                if (!categoryExist)
                {
                    _logger.LogWarning("Category with Id {CategoryId} does not exist.", product.CategoryId);
                    return false;
                }

                _logger.LogInformation("Category exists. Creating product.");
                var PRODUCT = new Product
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Stock = product.Stock,
                    CategoryId = product.CategoryId
                };

                _logger.LogInformation("Saving new product to the database.");
                _context.Add(PRODUCT);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Product saved to Database successfully.");

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while creating a new product.");
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var result = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result == null)
            {
                return false;
            }

            _context.Products.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductResponseDto>> GetAllProductAsync()
        {
            return await _context.Products.AsNoTracking()
                .Select(P => new ProductResponseDto
                {
                    Id = P.Id,
                    ProductName = P.ProductName,
                    Price = P.Price,
                    Stock = P.Stock,
                    CategoryName = P.category.CategoryName
                })
                .ToListAsync();
        }

        public async Task<ProductResponseDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.Include(P=>P.category).FirstOrDefaultAsync(P => P.Id == id);
            if(product==null)
            {
                return null;
            }
            return new ProductResponseDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Stock=product.Stock,
                CategoryName = product.category.CategoryName
            };

        }

        public Task<bool> UpdateProductAsync(int id, UpdateProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
