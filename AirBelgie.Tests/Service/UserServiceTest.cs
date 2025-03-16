using AirBelgie.Data;
using AirBelgie.Model;
using AirBelgie.Service;
using AirBelgie.Tests.Controller.Mocks;
using Moq;

namespace AirBelgie.Tests.Service;

public class UserServiceTest
{
    private readonly UserServiceMock _mockUserService = new UserServiceMock();
    private readonly Guid _testUserId = Guid.Parse("b8c8637b-acd4-4f68-9b06-0c0904737568");
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
    {
        var user = await _mockUserService.GetByIdAsync(_testUserId.ToString());
        Assert.NotNull(user);
        Assert.Equal(_testUserId, user.Id);
    }

    [Fact]
    public async Task GetByEmailAsync_ShouldReturnUser_WhenEmailExists()
    {
        var user = await _mockUserService.GetByEmailAsync("test@example.com");
        Assert.NotNull(user);
        Assert.Equal("test@example.com", user.Email);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddUser_WhenUserDoesNotExist()
    {
        var newUser = new User { Email = "new@example.com", Username = "newuser", Password = "test" };
        var createdUser = await _mockUserService.CreateAsync(newUser);
        Assert.NotNull(createdUser);
        Assert.Equal("new@example.com", createdUser.Email);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnNull_WhenUserAlreadyExists()
    {
        var existingUser = new User { Id = _testUserId, Email = "test@example.com", Username = "testuser", Password = "test" };
        var result = await _mockUserService.CreateAsync(existingUser);
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldModifyUser_WhenUserExists()
    {
        User? existingUser = await _mockUserService.GetByIdAsync(_testUserId.ToString());
        Assert.NotNull(existingUser);
        
        existingUser.Email = "updated@example.com";

        var result = await _mockUserService.UpdateAsync(existingUser);
        Assert.NotNull(result);
        Assert.Equal("updated@example.com", result.Email);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveUser_WhenUserExists()
    {
        var result = await _mockUserService.DeleteAsync(_testUserId.ToString());
        Assert.True(result);
    }
}