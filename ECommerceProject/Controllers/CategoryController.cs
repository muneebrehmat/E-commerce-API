using ECommerceProject.DTOs.CategoryDTO;
using ECommerceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var result = await _service.CreateCategory(dto);
            if(result)
            {
                return Ok("Category Created Successfully");
            }
            return BadRequest("Error while Creating Category");
           
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _service.GetAllCategory();
            return Ok(categories);
        }
    }
}
