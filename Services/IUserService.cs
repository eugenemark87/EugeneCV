using EugeneCV.Models;

namespace EugeneCV.Services
{
    public interface IUserService
    {
        Task<User?> AuthenticateUserAsync(string username, string password);
    }
}
