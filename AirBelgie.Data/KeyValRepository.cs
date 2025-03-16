using System.Data;
using System.Text.Json;
using Dapper;

namespace AirBelgie.Data;

public class KeyValRepository : IKeyValRepository
{
    private readonly DatabaseContext _dbContext;
    
    public KeyValRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> CreateOrUpdateKeyValAsync<T>(string key, T value)
    {
        string sqlQuery = @"
            INSERT INTO keyval (key, value)
            VALUES (@key, @value)
            ON CONFLICT (key) DO UPDATE
            SET value = @value";
        string valueString = JsonSerializer.Serialize(value);
        int result = await _dbContext.CreateConnection().ExecuteAsync(sqlQuery, new { key, valueString });
        
        return result;
    }

    public async Task<T?> GetKeyValAsync<T>(string key)
    {
        string sqlQuery = "SELECT value FROM keyval WHERE key = @key";
        string? valueString = await _dbContext.CreateConnection().QuerySingleOrDefaultAsync<string>(sqlQuery, new { key });
            
        return valueString is not null ? JsonSerializer.Deserialize<T>(valueString) : default;
    }

    public async Task<bool> DeleteKeyValAsync(string key)
    {
        string sqlQuery = "DELETE FROM keyval WHERE key = @key";
        
        return await _dbContext.CreateConnection().ExecuteAsync(sqlQuery, new { key }) > 0;
    }
}