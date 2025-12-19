using Kaira.WebUI.DTOs.MainSliderDtos;

namespace Kaira.WebUI.Repositories.IMainSliderRepositories
{
    public interface IMainSliderRepository
    {
        Task<IEnumerable<ResultMainSliderDto>> GetAllAsync();
        Task<UpdateMainSliderDto> GetByIdAsync(int id);
        Task CreateAsync(CreateMainSliderDto mainSliderDto);
        Task UpdateAsync(UpdateMainSliderDto mainSliderDto);
        Task DeleteAsync(int id);
    }
}
