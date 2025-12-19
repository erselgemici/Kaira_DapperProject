using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.CategoryDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.CategoryRepositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            string query = "insert into categories (name) values (@Name)"; //@Name ile dtodaki isim aynı olmalı çalışması için
            var parameters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from categories where CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "select * from categories";
            return await _db.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            string query = "SELECT CategoryId, Name FROM Categories WHERE CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var query = "update categories set name = @Name where CategoryId = @CategoryId";
            var parameters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
