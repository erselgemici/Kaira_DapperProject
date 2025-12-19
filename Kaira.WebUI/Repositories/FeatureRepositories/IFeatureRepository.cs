using Kaira.WebUI.DTOs.FeatureDtos;

namespace Kaira.WebUI.Repositories.FeatureRepositories
{
    public interface IFeatureRepository
    {
        Task<IEnumerable<ResultFeatureDto>> GetAllAsync();
        Task<UpdateFeatureDto> GetByIdAsync(int id);
        Task CreateAsync(CreateFeatureDto featureDto);
        Task UpdateAsync(UpdateFeatureDto featureDto);
        Task DeleteAsync(int id);
    }
}
