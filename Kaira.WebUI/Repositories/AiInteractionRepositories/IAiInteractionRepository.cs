using Kaira.WebUI.DTOs.AiInteractionDtos;

namespace Kaira.WebUI.Repositories.AiInteractionRepositories
{
    public interface IAiInteractionRepository
    {
        Task CreateAsync(CreateAiInteractionDto createAiInteractionDto);
    }
}
