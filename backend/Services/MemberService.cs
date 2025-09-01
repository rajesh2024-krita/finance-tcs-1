
using FintcsApi.Models;
using FintcsApi.DTOs;
using FintcsApi.Repositories;

namespace FintcsApi.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberRepository.GetAllAsync();
        }

        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<Member?> GetMemberByMemNoAsync(string memNo)
        {
            return await _memberRepository.GetByMemNoAsync(memNo);
        }

        public async Task<Member> CreateMemberAsync(MemberDto memberDto)
        {
            var member = new Member
            {
                MemNo = memberDto.MemNo,
                Name = memberDto.Name,
                SocietyId = memberDto.SocietyId,
                CreatedAt = DateTime.UtcNow
            };

            return await _memberRepository.CreateAsync(member);
        }

        public async Task<Member> UpdateMemberAsync(Member member)
        {
            return await _memberRepository.UpdateAsync(member);
        }

        public async Task DeleteMemberAsync(int id)
        {
            await _memberRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Member>> GetMembersBySocietyIdAsync(int societyId)
        {
            return await _memberRepository.GetBySocietyIdAsync(societyId);
        }
    }
}
