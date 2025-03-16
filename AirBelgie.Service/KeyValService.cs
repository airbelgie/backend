using AirBelgie.Data;

namespace AirBelgie.Service;

public class KeyValService : IKeyValService
{

    private readonly IKeyValRepository _keyValRepository;
    
    public KeyValService(IKeyValRepository keyValRepository)
    {
        _keyValRepository = keyValRepository;
    }
    
    public async Task<bool> CreateOrUpdateKeyValAsync<T>(string key, T value)
    {
        return await _keyValRepository.CreateOrUpdateKeyValAsync<T>(key, value) == 1;
    }

    public async Task<T?> GetKeyValAsync<T>(string key)
    {
        T? keyVal = await _keyValRepository.GetKeyValAsync<T>(key);
        
        return keyVal;
    }

    public async Task<bool> DeleteKeyValAsync(string key)
    {
        return await _keyValRepository.DeleteKeyValAsync(key);
    }
}