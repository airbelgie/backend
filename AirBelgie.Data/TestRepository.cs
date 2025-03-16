using System.Data;
using Dapper;

namespace AirBelgie.Data;

public class TestData
{
    public required string CurrentSchema { get; set; }
}

public class TestRepository : ITestRepository
{
    private readonly IDbConnection _dbConnection;

    public TestRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public TestData GetSchema()
    {
        string sqlQuery = "SELECT current_schema()";

        var schema = _dbConnection.QueryFirst<TestData>(sqlQuery);
        return schema;
    }
}