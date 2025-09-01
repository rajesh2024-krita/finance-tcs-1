
using FintcsApi.Models;
using FintcsApi.DTOs;

namespace FintcsApi.Services
{
    public interface ISocietyService
    {
        Task<IEnumerable<Society>> GetAllSocietiesAsync();
        Task<Society?> GetSocietyByIdAsync(int id);
        Task<Society> CreateSocietyAsync(SocietyDto societyDto);
        Task<Society> UpdateSocietyAsync(Society society);
        Task DeleteSocietyAsync(int id);
    }
}
