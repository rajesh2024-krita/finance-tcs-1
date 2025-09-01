
using FintcsApi.Models;

namespace FintcsApi.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task<Member?> GetByMemNoAsync(string memNo);
        Task<Member> CreateAsync(Member member);
        Task<Member> UpdateAsync(Member member);
        Task DeleteAsync(int id);
        Task<IEnumerable<Member>> GetBySocietyIdAsync(int societyId);
    }
}
