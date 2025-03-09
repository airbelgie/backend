using System.Data;
using AirBelgie.Model;
using Dapper;

namespace AirBelgie.Data;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;

    public UserRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetUserByIdAsync(string id)
    {
        using IDbConnection connection = _dbContext.CreateConnection();
        
        string sqlQuery = "SELECT * FROM users WHERE id = @id::uuid";

        return await connection.QuerySingleOrDefaultAsync<User>(sqlQuery, new { id });
    }
}