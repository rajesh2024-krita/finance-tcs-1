
using System.ComponentModel.DataAnnotations;

namespace FintcsApi.DTOs
{
    public class SocietyDto
    {
        [Required]
        public string SocietyName { get; set; }
        
        public string? Address { get; set; }
        
        public string? City { get; set; }
        
        public string? Phone { get; set; }
        
        public string? Fax { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }
        
        public string? Website { get; set; }
        
        public string? RegistrationNumber { get; set; }
        
        public object? Tabs { get; set; }
    }
    
    public class SocietyApprovalStatusDto
    {
        public bool HasPendingChanges { get; set; }
        public string? ChangeRequestId { get; set; }
        public int TotalUsers { get; set; }
        public int ApprovedCount { get; set; }
        public int PendingCount { get; set; }
        public List<UserApprovalDto> ApprovedUsers { get; set; } = new List<UserApprovalDto>();
        public List<UserApprovalDto> PendingUsers { get; set; } = new List<UserApprovalDto>();
        public List<UserApprovalDto> AllUsers { get; set; } = new List<UserApprovalDto>();
        public string? PendingChanges { get; set; }
    }
    
    public class UserApprovalDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? EdpNo { get; set; }
        public bool HasApproved { get; set; }
        public string? ApprovedAt { get; set; }
        public string Status { get; set; }
    }
}
