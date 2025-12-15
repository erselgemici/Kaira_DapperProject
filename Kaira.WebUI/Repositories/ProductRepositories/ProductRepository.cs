using Dapper;
using Kaira.WebUI.Context;
using Kaira.WebUI.DTOs.ProductDtos;
using System.Data;

namespace Kaira.WebUI.Repositories.ProductRepositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateProductDto productDto)
        {
            var query = "insert into products (name,ImageUrl,description,price,categoryId) values (@Name,@ImageUrl,@Description,@Price,@CategoryId)";
            var parameters = new DynamicParameters(productDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from products where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            string query = "select p.name,c.name as categoryName,price,ImageUrl,description,productId from products as p inner join categories as c on c.CategoryId=p.CategoryId";
            return await _db.QueryAsync<ResultProductDto>(query);
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            string query = "select * from products where ProductId=@ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateProductDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateProductDto productDto)
        {
            string query = "update products set name=@Name, ImageUrl=@ImageUrl, description=@Description, price=@Price, categoryId=@CategoryId where ProductId=@ProductId";
            var parameters = new DynamicParameters(productDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
