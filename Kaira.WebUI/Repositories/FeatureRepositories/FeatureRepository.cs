using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.FeatureDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.FeatureRepositories
{
    public class FeatureRepository(AppDbContext context) : IFeatureRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateFeatureDto featureDto)
        {
            var query = "Insert Into Features (Title, Description, IconSvg) values (@Title, @Description, @IconSvg)";
            var parameters = new DynamicParameters(featureDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "Delete From Features Where FeatureId=@FeatureId";
            var parameters = new DynamicParameters();
            parameters.Add("@FeatureId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultFeatureDto>> GetAllAsync()
        {
            string query = "Select * From Features";
            return await _db.QueryAsync<ResultFeatureDto>(query);
        }

        public async Task<UpdateFeatureDto> GetByIdAsync(int id)
        {
            string query = "Select * From Features Where FeatureId=@FeatureId";
            var parameters = new DynamicParameters();
            parameters.Add("@FeatureId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateFeatureDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateFeatureDto featureDto)
        {
            string query = "Update Features Set Title=@Title, Description=@Description, IconSvg=@IconSvg Where FeatureId=@FeatureId";
            var parameters = new DynamicParameters(featureDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
