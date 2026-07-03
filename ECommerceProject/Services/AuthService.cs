using ECommerceProject.DTOs.LoginDTO;
using ECommerceProject.DTOs.RegisterDTO;
using ECommerceProject.Interfaces;

namespace ECommerceProject.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
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
            var token = await _userRepository.LoginAsync(dto);
            if(token==null)
            {
                return null;
            }
            return token;
        }
    }
}
