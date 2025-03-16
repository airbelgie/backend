using System.Text.Json;
using AirBelgie.Model;
using AirBelgie.Service;

namespace AirBelgie.Tests.Controller.Mocks;

public class KeyValServiceMock : IKeyValService
{
    private readonly List<KeyVal> _keyVals = new()
    {
        new KeyVal { Key = "test", Value = "\"testValue\"" }
    };
    
    public Task<bool> CreateOrUpdateKeyValAsync<T>(string key, T value)
    {
        string valueString = JsonSerializer.Serialize(value);
        KeyVal? kv = _keyVals.FirstOrDefault(v => v.Key == key);
        if (kv is not null)
        {
            kv.Value = valueString;
        }
        else
        {
            _keyVals.Add(new KeyVal { Key = key, Value = valueString });
        }
        
        return Task.FromResult(true);
    }

    public Task<T?> GetKeyValAsync<T>(string key)
    {
        KeyVal? kv = _keyVals.FirstOrDefault(v => v.Key == key);

        return Task.FromResult<T?>(kv is not null ? JsonSerializer.Deserialize<T>(kv.Value) : default);
    }

    public Task<bool> DeleteKeyValAsync(string key)
    {
        _keyVals.RemoveAll(v => v.Key == key);
        return Task.FromResult(true);
    }
}