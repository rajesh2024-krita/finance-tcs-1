
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using FintcsApi.DTOs;
using FintcsApi.Models;
using FintcsApi.Repositories;

namespace FintcsApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        
        public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
                
                if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                {
                    return new ApiResponse<LoginResponse>
                    {
                        Success = false,
                        Message = "Invalid credentials",
                        Errors = new List<string> { "Username or password is incorrect" }
                    };
                }
                
                var token = GenerateJwtToken(user);
                var expiresAt = DateTime.UtcNow.AddHours(int.Parse(_configuration["JwtSettings:ExpiryInHours"]));
                
                var details = new
                {
                    EDPNo = user.EDPNo,
                    Name = user.Name,
                    AddressOffice = user.AddressOffice,
                    AddressResidential = user.AddressResidential,
                    Designation = user.Designation,
                    PhoneOffice = user.PhoneOffice,
                    PhoneResidential = user.PhoneResidential,
                    Mobile = user.Mobile,
                    Email = user.Email
                };
                
                var response = new LoginResponse
                {
                    Token = token,
                    Username = user.Username,
                    Email = user.Email,
                    Phone = user.Phone,
                    Roles = user.Roles,
                    Details = details,
                    ExpiresAt = expiresAt
                };
                
                return new ApiResponse<LoginResponse>
                {
                    Success = true,
                    Message = "Login successful",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<LoginResponse>
                {
                    Success = false,
                    Message = "Internal server error occurred during login",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
        
        public async Task<ApiResponse<User>> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                // Check if username exists
                var existingUser = await _userRepository.GetByUsernameAsync(registerDto.Username);
                if (existingUser != null)
                {
                    return new ApiResponse<User>
                    {
                        Success = false,
                        Message = "User already exists",
                        Errors = new List<string> { $"Username '{registerDto.Username}' is already taken" }
                    };
                }
                
                // Check if email exists
                var existingEmail = await _userRepository.GetByEmailAsync(registerDto.Email);
                if (existingEmail != null)
                {
                    return new ApiResponse<User>
                    {
                        Success = false,
                        Message = "Email already registered",
                        Errors = new List<string> { $"Email '{registerDto.Email}' is already registered" }
                    };
                }
                
                var user = new User
                {
                    Username = registerDto.Username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                    Email = registerDto.Email,
                    Phone = registerDto.Phone,
                    Roles = "user",
                    EDPNo = registerDto.EDPNo,
                    Name = registerDto.Name,
                    AddressOffice = registerDto.AddressOffice,
                    AddressResidential = registerDto.AddressResidential,
                    Designation = registerDto.Designation,
                    PhoneOffice = registerDto.PhoneOffice,
                    PhoneResidential = registerDto.PhoneResidential,
                    Mobile = registerDto.Mobile
                };
                
                var createdUser = await _userRepository.CreateAsync(user);
                
                return new ApiResponse<User>
                {
                    Success = true,
                    Message = "User registered successfully",
                    Data = createdUser
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<User>
                {
                    Success = false,
                    Message = "Internal server error occurred during registration",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
        
        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var claims = new List<Claim>
            {
                new Claim("unique_name", user.Username),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("role", user.Roles)
            };
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["JwtSettings:ExpiryInHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
