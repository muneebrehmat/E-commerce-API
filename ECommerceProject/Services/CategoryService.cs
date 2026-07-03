using ECommerceProject.DTOs.CategoryDTO;
using ECommerceProject.Interfaces;
using ECommerceProject.Models;

namespace ECommerceProject.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> CreateCategory(CreateCategoryDto dto)
        {
            var result = await _categoryRepository.CreateCategoryAsync(dto);
            if(result)
            {
                return true;
            }
            return false;
        }
        public async Task<List<CategoryResponseDto>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategoryAsync();
           
        }
    }
}
