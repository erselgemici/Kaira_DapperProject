using Kaira.WebUI.DTOs.TestimonialDtos;

namespace Kaira.WebUI.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<IEnumerable<ResultTestimonialDto>> GetAllAsync();
        Task<UpdateTestimonialDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTestimonialDto testimonialDto);
        Task UpdateAsync(UpdateTestimonialDto testimonialDto);
        Task DeleteAsync(int id);
    }
}
