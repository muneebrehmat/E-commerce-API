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

        public UserRepository(ApplicationDbContext context,JwtHelper jwt)
        {
           _context = context;
            _jwt = jwt;
        }
        public async Task<bool> CreateUserAsync(RegistrationDto dto)
        {
            var ExistingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName);
            if(ExistingUser==null)
            {
                var CreateUser = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    Password = dto.Password,
                    Role = "Customer"
                };
                _context.Users.Add(CreateUser);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

            
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email && u.Password == dto.Password);
            if(user==null)
            {
                return null;
            }
            var token = _jwt.GenerateToken(user);
            return token;
           
        }
    }
}
