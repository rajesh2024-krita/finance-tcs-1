
namespace FintcsApi.Models
{
    public class SocietyApproval
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
        
        public bool HasApproved { get; set; } = false;
        
        public DateTime? ApprovedAt { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
