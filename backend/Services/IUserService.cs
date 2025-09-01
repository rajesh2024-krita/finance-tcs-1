
using FintcsApi.Models;
using FintcsApi.DTOs;

namespace FintcsApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(RegisterDto registerDto);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
