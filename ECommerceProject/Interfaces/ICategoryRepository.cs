using ECommerceProject.DTOs.CategoryDTO;

namespace ECommerceProject.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> CreateCategoryAsync(CreateCategoryDto dto);
        Task<List<CategoryResponseDto>> GetAllCategoryAsync();
    }
}
