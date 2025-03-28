using EugeneCV.Data;
using EugeneCV.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.IO.Enumeration;

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

        public async Task<string> GetUserRole(int roleId)
        {
            var obj = await _dbContext.Roles.FirstOrDefaultAsync(u => u.RoleId == roleId);

            if (obj != null)
            {
                return obj.Name;
            }
            return "";
        }

        public async Task SaveLoggedInDate(int userId)
        {
            var obj = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (obj != null)
            {
                obj.LastLoggedIn = System.DateTime.Now;

                _dbContext.Users.Update(obj);
                await _dbContext.SaveChangesAsync();

            }
         
        }


    }
}
