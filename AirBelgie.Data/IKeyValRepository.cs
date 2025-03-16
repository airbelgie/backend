namespace AirBelgie.Data;

public interface IKeyValRepository
{
    Task<int> CreateOrUpdateKeyValAsync<T>(string key, T value);
    Task<T?> GetKeyValAsync<T>(string key);
    Task<bool> DeleteKeyValAsync(string key);
}