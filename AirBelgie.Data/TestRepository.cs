using Dapper;
using Npgsql;

namespace AirBelgie.Data;

public class TestData
{
    public string CurrentSchema { get; set; }
}

public class TestRepository
{
    private NpgsqlConnection _connection;

    public TestRepository()
    {
        _connection = new NpgsqlConnection("Server=localhost;User Id=airbelgie;Password=airbelgie;");
        _connection.Open();
    }
    
    public TestData GetSchema()
    {
        string sqlQuery = "SELECT current_schema()";
        
        var schema = _connection.QueryFirst<TestData>(sqlQuery);
        return schema;
    }
}