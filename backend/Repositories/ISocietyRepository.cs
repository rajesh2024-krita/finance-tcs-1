
using FintcsApi.Models;

namespace FintcsApi.Repositories
{
    public interface ISocietyRepository
    {
        Task<Society?> GetAsync();
        Task<Society> CreateAsync(Society society);
        Task<Society> UpdateAsync(Society society);
        Task<bool> ExistsAsync();
        Task<List<SocietyApproval>> GetApprovalsAsync();
        Task<SocietyApproval?> GetUserApprovalAsync(int userId);
        Task<SocietyApproval> AddApprovalAsync(SocietyApproval approval);
        Task ClearApprovalsAsync();
    }
}
