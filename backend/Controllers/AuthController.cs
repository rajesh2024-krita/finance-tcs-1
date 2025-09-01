
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FintcsApi.DTOs;
using FintcsApi.Services;

namespace FintcsApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Invalid input data",
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });
            }
            
            var result = await _authService.LoginAsync(loginDto);
            
            if (!result.Success)
            {
                return Unauthorized(result);
            }
            
            return Ok(result);
        }
        
        [HttpPost("register")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Invalid input data",
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
                });
            }
            
            var result = await _authService.RegisterAsync(registerDto);
            
            if (!result.Success)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }
        
        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = new List<string> { "user", "admin" };
            
            return Ok(new ApiResponse<List<string>>
            {
                Success = true,
                Message = "Valid roles retrieved successfully",
                Data = roles
            });
        }
    }
}
