using Kaira.WebUI.DTOs.CategoryDtos;

namespace Kaira.WebUI.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllAsync();
        Task<UpdateCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto categoryDto);
        Task UpdateAsync(UpdateCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
