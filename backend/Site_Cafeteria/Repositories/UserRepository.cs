using System.Data;
using System.Data.SqlClient;
using Dapper;
using Site_Cafeteria.Entities;

namespace Site_Cafeteria.Repositories;

public class UserRepository : IUserRepository
{

    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    public async Task Create(User user)
    {
        var parameters = new{
            @Id = Guid.NewGuid(),
            @Name = user.Name,
            @Password = user.Password,
            @Email = user.Email,
            @BirthDate = user.BirthDate
        };
        using (var conn = GetConnection())
        {
            if (conn.State != ConnectionState.Open) conn.Open();

            string query = @"INSERT INTO TB_USER (ID, NAME, EMAIL, PASSWORD, BIRTH_DATE) VALUES 
            (
                @Id,
                @Name,
                @Email,
                @Password,
                @BirthDate
            )";


            await conn.ExecuteAsync(query, parameters);
        }
    }

    public async Task<bool> Login(Login dto)
    {
        var parameters = new{
            @Username = dto.UserName,
            @Password = dto.Password
        };
        using (var conn = GetConnection())
        {
            if (conn.State != ConnectionState.Open) conn.Open();

            string query = @"SELECT Id FROM TB_USER WHERE EMAIL = @Username and PASSWORD = @Password;";

            var result = await conn.QueryAsync<string>(query, parameters);
            return result.Any();
        }
    }

    private  SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("sqlDB"));
    }

}
