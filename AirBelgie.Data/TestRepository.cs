using Dapper;
using Npgsql;
using Microsoft.Extensions.Options;

namespace AirBelgie.Data;

public class TestData
{
    public string CurrentSchema { get; set; }
}

public class TestRepository : ITestRepository
{
    private readonly NpgsqlConnection _connection;
    private DbSettings _dbSettings;

    public TestRepository(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
        _connection = new NpgsqlConnection($"Server={_dbSettings.Server};Port={_dbSettings.Port};Database={_dbSettings.Database};User ID={_dbSettings.User};Password={_dbSettings.Password};");
        _connection.Open();
    }
    
    public TestData GetSchema()
    {
        string sqlQuery = "SELECT current_schema()";
        
        var schema = _connection.QueryFirst<TestData>(sqlQuery);
        return schema;
    }
}