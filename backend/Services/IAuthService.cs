
using FintcsApi.DTOs;
using FintcsApi.Models;

namespace FintcsApi.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponse>> LoginAsync(LoginDto loginDto);
        Task<ApiResponse<User>> RegisterAsync(RegisterDto registerDto);
        string GenerateJwtToken(User user);
    }
}
