using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.FeatureDtos;
using Kaira.WebUI.DTOs.PartnerDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.PartnerRepositories
{
    public class PartnerRepository(AppDbContext context) : IPartnerRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreatePartnerDto partnerDto)
        {
            var query = "Insert Into Partners (PartnerName, LogoUrl) values (@PartnerName, @LogoUrl)";
            var parameters = new DynamicParameters(partnerDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "Delete From Partners Where PartnerId=@PartnerId";
            var parameters = new DynamicParameters();
            parameters.Add("@PartnerId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultPartnerDto>> GetAllAsync()
        {
            string query = "Select * From Partners";
            return await _db.QueryAsync<ResultPartnerDto>(query);
        }

        public async Task<UpdatePartnerDto> GetByIdAsync(int id)
        {
            string query = "Select * From Partners Where PartnerId=@PartnerId";
            var parameters = new DynamicParameters();
            parameters.Add("@PartnerId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdatePartnerDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdatePartnerDto partnerDto)
        {
            string query = "Update Partners Set PartnerName=@PartnerName, LogoUrl=@LogoUrl Where PartnerId=@PartnerId";
            var parameters = new DynamicParameters(partnerDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
