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
    
    public async Task<User?> CreateUserAsync(User user)
    {
        string sqlQuery = "INSERT INTO users (username, password, email) VALUES (@Username, @Password, @Email) RETURNING *";

        return await _dbContext.CreateConnection().QuerySingleAsync<User>(sqlQuery, user);
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        string sqlQuery = "DELETE FROM users WHERE id = @id";

        int result = await _dbContext.CreateConnection().ExecuteAsync(sqlQuery, new { id });
        
        return result > 0;
    }
    
    public async Task<User?> GetUserByIdAsync(string id)
    {
        string sqlQuery = "SELECT * FROM users WHERE id = @id::uuid";

        return await _dbContext.CreateConnection().QuerySingleOrDefaultAsync<User>(sqlQuery, new { id });
    }
    
    public async Task<User?> GetUserByEmailAsync(string email) 
    {
        string sqlQuery = "SELECT * FROM users WHERE email = @email";

        return await _dbContext.CreateConnection().QuerySingleOrDefaultAsync<User>(sqlQuery, new { email });
    }

    public Task<User?> GetUserByUsernameAsync(string username)
    {
        string sqlQuery = "SELECT * FROM users WHERE username = @username";
        
        return _dbContext.CreateConnection().QuerySingleOrDefaultAsync<User>(sqlQuery, new { username });
    }

    public async Task<User?> GetUserByEmailOrUsernameAsync(string value)
    {
        string sqlQuery = "SELECT * FROM users WHERE email = @value OR username = @value";

        return await _dbContext.CreateConnection().QuerySingleOrDefaultAsync<User>(sqlQuery, new { value });
    }
    
    public async Task<User?> UpdateUserAsync(User user)
    {
        string sqlQuery = "UPDATE users SET username = @Username, password = @Password, email = @Email WHERE id = @Id RETURNING *";

        return await _dbContext.CreateConnection().QuerySingleAsync<User>(sqlQuery, user);
    }
}