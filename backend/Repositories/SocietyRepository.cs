
using Microsoft.EntityFrameworkCore;
using FintcsApi.Data;
using FintcsApi.Models;

namespace FintcsApi.Repositories
{
    public class SocietyRepository : ISocietyRepository
    {
        private readonly FintcsDbContext _context;
        
        public SocietyRepository(FintcsDbContext context)
        {
            _context = context;
        }
        
        public async Task<Society?> GetAsync()
        {
            return await _context.Societies.FirstOrDefaultAsync();
        }
        
        public async Task<Society> CreateAsync(Society society)
        {
            _context.Societies.Add(society);
            await _context.SaveChangesAsync();
            return society;
        }
        
        public async Task<Society> UpdateAsync(Society society)
        {
            society.UpdatedAt = DateTime.UtcNow;
            _context.Societies.Update(society);
            await _context.SaveChangesAsync();
            return society;
        }
        
        public async Task<bool> ExistsAsync()
        {
            return await _context.Societies.AnyAsync();
        }
        
        public async Task<List<SocietyApproval>> GetApprovalsAsync()
        {
            return await _context.SocietyApprovals.Include(a => a.User).ToListAsync();
        }
        
        public async Task<SocietyApproval?> GetUserApprovalAsync(int userId)
        {
            return await _context.SocietyApprovals.FirstOrDefaultAsync(a => a.UserId == userId);
        }
        
        public async Task<SocietyApproval> AddApprovalAsync(SocietyApproval approval)
        {
            _context.SocietyApprovals.Add(approval);
            await _context.SaveChangesAsync();
            return approval;
        }
        
        public async Task ClearApprovalsAsync()
        {
            _context.SocietyApprovals.RemoveRange(_context.SocietyApprovals);
            await _context.SaveChangesAsync();
        }
    }
}
