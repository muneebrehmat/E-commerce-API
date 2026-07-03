using ECommerceProject.DTOs.LoginDTO;
using ECommerceProject.DTOs.RegisterDTO;
using ECommerceProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthenticationController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> CreateUser(RegistrationDto dto)
        {
            var result = await _authService.CreateUser(dto);
            if(result)
            {
                return Ok("User Created");
            }
            return BadRequest("Error.........");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.Login(dto);
            if (token==null)
            {
                return BadRequest("Invalid UserName");
            }
            return Ok(new { token });
        }
    }
}
