using Kaira.WebUI.DTOs.VideoDtos;

namespace Kaira.WebUI.Repositories.VideoRepositories
{
    public interface IVideoRepository
    {
        Task<IEnumerable<ResultVideoDto>> GetAllAsync();
        Task<UpdateVideoDto> GetByIdAsync(int id);
        Task CreateAsync(CreateVideoDto videoDto);
        Task UpdateAsync(UpdateVideoDto videoDto);
        Task DeleteAsync(int id);
    }
}
