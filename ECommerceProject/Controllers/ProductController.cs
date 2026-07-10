using ECommerceProject.DTOs.ProductDTO;
using ECommerceProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var result = await _service.createProduct(dto);
            if(result)
            {
                return Ok("Product created");
            }
            return BadRequest("Error..........");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _service.GetAllProduct();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductById(id);
            if(product==null)
            {
                return BadRequest("Product Not found");
            }
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _service.DeleteProduct(id);
            if (result)
            {
                return Ok("Product deleted successfully");
            }
            return NotFound("Product Not Found");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id,UpdateProductDto dto)
        {
            var result = await _service.UpdateProduct(id, dto);
            if(result)
            {
                return Ok("Product Update successfully");

            }
            return NotFound("Product Not Found");
        }
    }
}
