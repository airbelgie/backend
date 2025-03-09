using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace AirBelgie.Data;

public class DatabaseContext
{
    private DbSettings _dbSettings;

    public DatabaseContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString =
            $"Host={_dbSettings.Server}; Database={_dbSettings.Database}; Username={_dbSettings.User}; Password={_dbSettings.Password};";
        return new NpgsqlConnection(connectionString);
    }
}