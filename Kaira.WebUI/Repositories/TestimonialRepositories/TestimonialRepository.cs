using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.TestimonialDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(AppDbContext context) : ITestimonialRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateTestimonialDto testimonialDto)
        {
            var query = "insert into testimonials (NameSurname, Comment) values (@NameSurname, @Comment)";
            var parameters = new DynamicParameters(testimonialDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from testimonials where TestimonialId=@TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultTestimonialDto>> GetAllAsync()
        {
            string query = "select * from testimonials";
            return await _db.QueryAsync<ResultTestimonialDto>(query);
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
        {
            string query = "select * from testimonials where TestimonialId=@TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateTestimonialDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateTestimonialDto testimonialDto)
        {
            string query = "update testimonials set NameSurname=@NameSurname, Comment=@Comment where TestimonialId=@TestimonialId";
            var parameters = new DynamicParameters(testimonialDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
