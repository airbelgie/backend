namespace AirBelgie.Service;

public interface IKeyValService
{
    Task<bool> CreateOrUpdateKeyValAsync<T>(string key, T value);
    Task<T?> GetKeyValAsync<T>(string key);
    Task<bool> DeleteKeyValAsync(string key);
}