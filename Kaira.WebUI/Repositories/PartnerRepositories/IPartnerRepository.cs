using Kaira.WebUI.DTOs.PartnerDtos;

namespace Kaira.WebUI.Repositories.PartnerRepositories
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<ResultPartnerDto>> GetAllAsync();
        Task<UpdatePartnerDto> GetByIdAsync(int id);
        Task CreateAsync(CreatePartnerDto partnerDto);
        Task UpdateAsync(UpdatePartnerDto partnerDto);
        Task DeleteAsync(int id);
    }
}
