
using FintcsApi.Models;
using FintcsApi.DTOs;

namespace FintcsApi.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member?> GetMemberByIdAsync(int id);
        Task<Member?> GetMemberByMemNoAsync(string memNo);
        Task<Member> CreateMemberAsync(MemberDto memberDto);
        Task<Member> UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int id);
        Task<IEnumerable<Member>> GetMembersBySocietyIdAsync(int societyId);
    }
}
