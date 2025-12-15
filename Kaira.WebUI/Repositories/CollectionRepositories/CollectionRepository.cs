using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.CollectionDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CollectionRepositories
{
    public class CollectionRepository(AppDbContext context) : ICollectionRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateCollectionDto collectionDto)
        {
            var query = "insert into collections (ImageUrl, Title, Description) values (@ImageUrl, @Title, @Description)";
            var parameters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from collections where CollectionId=@CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCollectionDto>> GetAllAsync()
        {
            string query = "select * from collections";
            return await _db.QueryAsync<ResultCollectionDto>(query);
        }

        public async Task<UpdateCollectionDto> GetByIdAsync(int id)
        {
            string query = "select * from collections where CollectionId=@CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCollectionDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCollectionDto collectionDto)
        {
            string query = "update collections set ImageUrl=@ImageUrl, Title=@Title, Description=@Description where CollectionId=@CollectionId";
            var parameters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
