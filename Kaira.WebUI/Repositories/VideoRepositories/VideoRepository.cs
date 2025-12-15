using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.TestimonialDtos;
using Kaira.WebUI.DTOs.VideoDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.VideoRepositories
{
    public class VideoRepository(AppDbContext context) : IVideoRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateVideoDto videoDto)
        {
            var query = "insert into videos (Url, BackgroundImageUrl) values (@Url, @BackgroundImageUrl)";
            var parameters = new DynamicParameters(videoDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from videos where VideoId=@VideoId";
            var parameters = new DynamicParameters();
            parameters.Add("@VideoId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultVideoDto>> GetAllAsync()
        {
            string query = "select * from videos";
            return await _db.QueryAsync<ResultVideoDto>(query);
        }

        public async Task<UpdateVideoDto> GetByIdAsync(int id)
        {
            string query = "select * from videos where VideoId=@VideoId";
            var parameters = new DynamicParameters();
            parameters.Add("@VideoId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateVideoDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateVideoDto videoDto)
        {
            string query = "update videos set Url=@Url, BackgroundImageUrl=@BackgroundImageUrl where VideoId=@VideoId";
            var parameters = new DynamicParameters(videoDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
