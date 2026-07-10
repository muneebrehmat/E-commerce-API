using ECommerceProject.Data;
using ECommerceProject.DTOs.LoginDTO;
using ECommerceProject.DTOs.RegisterDTO;
using ECommerceProject.Helpers;
using ECommerceProject.Interfaces;
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwt;

        public UserRepository(ApplicationDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }
        public async Task<bool> CreateUserAsync(RegistrationDto registrationDto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == registrationDto.UserName);

            if (existingUser != null)
            {
                return false;
            }

            var user = new User
            {
                UserName = registrationDto.UserName,
                Email = registrationDto.Email,
                Password = registrationDto.Password,
                Role = "Customer"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string?> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Email == loginDto.Email &&
                    u.Password == loginDto.Password);

            if (user == null)
            {
                return null;
            }

            return _jwt.GenerateToken(user);
        }
    }
}
   
