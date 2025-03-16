using AirBelgie.Tests.Controller.Mocks;

namespace AirBelgie.Tests.Service;

public class KeyValServiceTest
{
    private readonly KeyValServiceMock _keyValServiceMock = new KeyValServiceMock();
    
    [Fact]
    public async Task CreateOrUpdateKeyValAsync_Should_Add_New_KeyVal()
    {
        string key = "newKey";
        string value = "newValue";

        bool result = await _keyValServiceMock.CreateOrUpdateKeyValAsync(key, value);
        string? retrievedValue = await _keyValServiceMock.GetKeyValAsync<string>(key);

        Assert.True(result);
        Assert.NotNull(retrievedValue);
        Assert.Equal(value, retrievedValue);
    }
    
    [Fact]
    public async Task CreateOrUpdateKeyValAsync_Should_Create_Int()
    {
        string key = "newKeyInt";
        int value = 42;

        bool result = await _keyValServiceMock.CreateOrUpdateKeyValAsync(key, value);
        int? retrievedValue = await _keyValServiceMock.GetKeyValAsync<int>(key);

        Assert.True(result);
        Assert.NotNull(retrievedValue);
        Assert.Equal(value, retrievedValue);
    }

    [Fact]
    public async Task CreateOrUpdateKeyValAsync_Should_Update_Existing_KeyVal()
    {
        string key = "test";
        string newValue = "updatedValue";

        bool result = await _keyValServiceMock.CreateOrUpdateKeyValAsync(key, newValue);
        string? retrievedValue = await _keyValServiceMock.GetKeyValAsync<string>(key);

        Assert.True(result);
        Assert.NotNull(retrievedValue);
        Assert.Equal(newValue, retrievedValue);
    }

    [Fact]
    public async Task GetKeyValAsync_Should_Return_Null_If_Key_Not_Found()
    {
        string key = "nonExistentKey";
        string? retrievedValue = await _keyValServiceMock.GetKeyValAsync<string>(key);

        Assert.Null(retrievedValue);
    }

    [Fact]
    public async Task DeleteKeyValAsync_Should_Remove_KeyVal()
    {
        string key = "test";

        bool result = await _keyValServiceMock.DeleteKeyValAsync(key);
        string? retrievedValue = await _keyValServiceMock.GetKeyValAsync<string>(key);

        Assert.True(result);
        Assert.Null(retrievedValue);
    }
}