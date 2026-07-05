using ECommerceProject.DTOs.LoginDTO;
using ECommerceProject.DTOs.RegisterDTO;
using ECommerceProject.Interfaces;

namespace ECommerceProject.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository,ILogger<AuthService> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(RegistrationDto dto)
        {
            var result = await _userRepository.CreateUserAsync(dto);
            if(result)
            {
                return true;
            }
            return false;
        }
        public async Task<string> Login(LoginDto dto)
        {
            _logger.LogInformation("Login Process Start........");
            var token = await _userRepository.LoginAsync(dto);
            if(token==null)
            {
                _logger.LogInformation("Login Failed");
                return null;
            }
            _logger.LogInformation("Login Successful");
            return token;
           
        }
    }
}
