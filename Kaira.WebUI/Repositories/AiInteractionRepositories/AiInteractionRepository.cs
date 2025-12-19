using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.AiInteractionDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.AiInteractionRepositories
{
    public class AiInteractionRepository(AppDbContext context) : IAiInteractionRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateAiInteractionDto createAiInteractionDto)
        {
            var query = "Insert Into AiInteractions (UserQuery, AiResponse) values (@UserQuery, @AiResponse)";
            var parameters = new DynamicParameters(createAiInteractionDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
