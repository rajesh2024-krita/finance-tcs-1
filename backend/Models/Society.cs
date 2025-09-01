
using System.ComponentModel.DataAnnotations;

namespace FintcsApi.Models
{
    public class Society
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string SocietyName { get; set; }
        
        public string? Address { get; set; }
        
        public string? City { get; set; }
        
        public string? Phone { get; set; }
        
        public string? Fax { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }
        
        public string? Website { get; set; }
        
        public string? RegistrationNumber { get; set; }
        
        public string Tabs { get; set; } = "{}";
        
        public bool IsPendingApproval { get; set; } = false;
        
        public string PendingChanges { get; set; } = "{}";
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
