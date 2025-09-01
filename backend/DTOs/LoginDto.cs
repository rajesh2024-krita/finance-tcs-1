
using System.ComponentModel.DataAnnotations;

namespace FintcsApi.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
    
    public class RegisterDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string? Phone { get; set; }
        
        public string? EDPNo { get; set; }
        
        public string? Name { get; set; }
        
        public string? AddressOffice { get; set; }
        
        public string? AddressResidential { get; set; }
        
        public string? Designation { get; set; }
        
        public string? PhoneOffice { get; set; }
        
        public string? PhoneResidential { get; set; }
        
        public string? Mobile { get; set; }
    }
    
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
    
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Roles { get; set; }
        public object? Details { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
