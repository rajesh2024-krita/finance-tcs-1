
using System.ComponentModel.DataAnnotations;

namespace FintcsApi.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string? Phone { get; set; }
        
        public string Roles { get; set; } = "user";
        
        public string? EDPNo { get; set; }
        
        public string? Name { get; set; }
        
        public string? AddressOffice { get; set; }
        
        public string? AddressResidential { get; set; }
        
        public string? Designation { get; set; }
        
        public string? PhoneOffice { get; set; }
        
        public string? PhoneResidential { get; set; }
        
        public string? Mobile { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
