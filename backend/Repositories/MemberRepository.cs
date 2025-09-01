
using Microsoft.EntityFrameworkCore;
using FintcsApi.Data;
using FintcsApi.Models;

namespace FintcsApi.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly FintcsDbContext _context;

        public MemberRepository(FintcsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await _context.Members
                .Include(m => m.Society)
                .ToListAsync();
        }

        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members
                .Include(m => m.Society)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Member?> GetByMemNoAsync(string memNo)
        {
            return await _context.Members
                .Include(m => m.Society)
                .FirstOrDefaultAsync(m => m.MemNo == memNo);
        }

        public async Task<Member> CreateAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member> UpdateAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Member>> GetBySocietyIdAsync(int societyId)
        {
            return await _context.Members
                .Include(m => m.Society)
                .Where(m => m.SocietyId == societyId)
                .ToListAsync();
        }
    }
}
