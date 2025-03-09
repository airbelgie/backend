using AirBelgie.Data;
using AirBelgie.Model;
using AirBelgie.Service;
using Moq;

namespace AirBelgie.Tests.Service;

public class UserServiceTest
{
    [Fact]
    public async Task GetById_ThrowsWhenUserIsNull()
    {
        // Arrange
        Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserByIdAsync(It.IsAny<string>())).ReturnsAsync(null as User);
        
        // Act
        UserService userService = new UserService(mockUserRepository.Object);

        // Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => userService.GetById("1"));
    }
    
    [Fact]
    public async Task GetById_ReturnsUserWhenFound()
    {
        // Arrange
        User expectedUser = new User() { Id = Guid.NewGuid(), Email = "test@test.com", Password = "test", Username = "Test" };
        Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserByIdAsync(It.IsAny<string>())).ReturnsAsync(expectedUser);
        
        // Act
        UserService userService = new UserService(mockUserRepository.Object);

        // Assert
        Assert.Equal(expectedUser, await userService.GetById("1"));
    }
}