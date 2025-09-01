
using System.ComponentModel.DataAnnotations;

namespace FintcsApi.DTOs
{
    public class MemberDto
    {
        [Required]
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
        
        public object? BankingDetails { get; set; }
    }
    
    public class BankingDetails
    {
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public string? IfscCode { get; set; }
        public string? Branch { get; set; }
    }
}
