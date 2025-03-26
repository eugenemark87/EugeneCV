using EugeneCV.Data;
using EugeneCV.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace EugeneCV.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<User?> AuthenticateUserAsync(string username, string password)
        {
            var obj = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (obj == null || !BCrypt.Net.BCrypt.Verify(password, obj.Password)) //verify against hashed password
            {
                return null; 
            }
                return obj; 
        }
    }
}
