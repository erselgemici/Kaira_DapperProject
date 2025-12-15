using Kaira.WebUI.DTOs.ProductDtos;

namespace Kaira.WebUI.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ResultProductDto>> GetAllAsync();
        Task<UpdateProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto productDto);
        Task UpdateAsync(UpdateProductDto productDto);
        Task DeleteAsync(int id);
    }
}
