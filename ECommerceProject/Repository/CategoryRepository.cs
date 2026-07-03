using ECommerceProject.Data;
using ECommerceProject.DTOs.CategoryDTO;
using ECommerceProject.Interfaces;
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
           _context = context;
        }
        public async Task<bool> CreateCategoryAsync(CreateCategoryDto dto)
        {
            var category = new Category
            {
                CategoryName = dto.Name
            };
            _context.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryResponseDto>> GetAllCategoryAsync()
        {
            return await _context.Categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.CategoryName
            })
                .ToListAsync();
            
        }

        
    }
}
