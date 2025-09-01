
using FintcsApi.Models;
using FintcsApi.DTOs;
using FintcsApi.Repositories;

namespace FintcsApi.Services
{
    public class SocietyService : ISocietyService
    {
        private readonly ISocietyRepository _societyRepository;

        public SocietyService(ISocietyRepository societyRepository)
        {
            _societyRepository = societyRepository;
        }

        public async Task<IEnumerable<Society>> GetAllSocietiesAsync()
        {
            return await _societyRepository.GetAllAsync();
        }

        public async Task<Society?> GetSocietyByIdAsync(int id)
        {
            return await _societyRepository.GetByIdAsync(id);
        }

        public async Task<Society> CreateSocietyAsync(SocietyDto societyDto)
        {
            var society = new Society
            {
                SocietyName = societyDto.SocietyName,
                CreatedAt = DateTime.UtcNow
            };

            return await _societyRepository.CreateAsync(society);
        }

        public async Task<Society> UpdateSocietyAsync(Society society)
        {
            return await _societyRepository.UpdateAsync(society);
        }

        public async Task DeleteSocietyAsync(int id)
        {
            await _societyRepository.DeleteAsync(id);
        }
    }
}
