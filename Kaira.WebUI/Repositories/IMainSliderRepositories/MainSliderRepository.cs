using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.MainSliderDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.IMainSliderRepositories
{
    public class MainSliderRepository(AppDbContext context) : IMainSliderRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateMainSliderDto mainSliderDto)
        {
            string query = "Insert Into MainSliders (Title, Description, ImageUrl, ButtonText, ButtonLink, IsActive) values (@Title, @Description, @ImageUrl, @ButtonText, @ButtonLink, @IsActive)"; 
            var parameters = new DynamicParameters(mainSliderDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "Delete From MainSliders Where MainSliderId=@MainSliderId";
            var parameters = new DynamicParameters();
            parameters.Add("@MainSliderId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultMainSliderDto>> GetAllAsync()
        {
            string query = "Select * From MainSliders";
            return await _db.QueryAsync<ResultMainSliderDto>(query);
        }

        public async Task<UpdateMainSliderDto> GetByIdAsync(int id)
        {
            string query = "Select * From MainSliders Where MainSliderId=@MainSliderId";
            var parameters = new DynamicParameters();
            parameters.Add("@MainSliderId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateMainSliderDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateMainSliderDto mainSliderDto)
        {
            string query = "Update MainSliders Set Title=@Title, Description=@Description, ImageUrl=@ImageUrl, ButtonText=@ButtonText, ButtonLink=@ButtonLink, IsActive=@IsActive Where MainSliderId=@MainSliderId";
            var parameters = new DynamicParameters(mainSliderDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
