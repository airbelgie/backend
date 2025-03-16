using System.Data;
using System.Text.Json;
using Dapper;

namespace AirBelgie.Data;

public class KeyValRepository : IKeyValRepository
{
    private readonly IDbConnection _dbConnection;
    
    public KeyValRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<int> CreateOrUpdateKeyValAsync<T>(string key, T value)
    {
        string sqlQuery = @"
            INSERT INTO keyval (key, value)
            VALUES (@key, @value)
            ON CONFLICT (key) DO UPDATE
            SET value = @value";
        string valueString = JsonSerializer.Serialize(value);
        int result = await _dbConnection.ExecuteAsync(sqlQuery, new { key, valueString });
        
        return result;
    }

    public async Task<T?> GetKeyValAsync<T>(string key)
    {
        string sqlQuery = "SELECT value FROM keyval WHERE key = @key";
        string? valueString = await _dbConnection.QuerySingleOrDefaultAsync<string>(sqlQuery, new { key });
            
        return valueString is not null ? JsonSerializer.Deserialize<T>(valueString) : default;
    }

    public async Task<bool> DeleteKeyValAsync(string key)
    {
        string sqlQuery = "DELETE FROM keyval WHERE key = @key";
        
        return await _dbConnection.ExecuteAsync(sqlQuery, new { key }) > 0;
    }
}