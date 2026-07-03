using ECommerceProject.DTOs.LoginDTO;
using ECommerceProject.DTOs.RegisterDTO;

namespace ECommerceProject.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(RegistrationDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
