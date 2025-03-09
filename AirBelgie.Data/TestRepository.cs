using System.Data;
using Dapper;

namespace AirBelgie.Data;

public class TestData
{
    public string CurrentSchema { get; set; }
}

public class TestRepository : ITestRepository
{
    private readonly DatabaseContext _dbContext;

    public TestRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public TestData GetSchema()
    {
        string sqlQuery = "SELECT current_schema()";

        using IDbConnection connection = _dbContext.CreateConnection();
        
        var schema = connection.QueryFirst<TestData>(sqlQuery);
        return schema;
    }
}