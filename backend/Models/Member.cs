
using System.ComponentModel.DataAnnotations;

namespace FintcsApi.Models
{
    public class Member
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string MemNo { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public string? FHName { get; set; }
        
        public string? OfficeAddress { get; set; }
        
        public string? City { get; set; }
        
        public string? PhoneOffice { get; set; }
        
        public string? Branch { get; set; }
        
        public string? PhoneRes { get; set; }
        
        public string? Mobile { get; set; }
        
        public string? Designation { get; set; }
        
        public string? ResidenceAddress { get; set; }
        
        public DateTime? DOB { get; set; }
        
        public DateTime? DOJSociety { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }
        
        public DateTime? DOJOrg { get; set; }
        
        public DateTime? DOR { get; set; }
        
        public string? Nominee { get; set; }
        
        public string? NomineeRelation { get; set; }
        
        public string BankingDetails { get; set; } = "{}";
        
        public bool IsPendingApproval { get; set; } = false;
        
        public string PendingChanges { get; set; } = "{}";
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
