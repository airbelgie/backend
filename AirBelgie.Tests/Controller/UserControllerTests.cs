using System.Net;

namespace AirBelgie.Tests.Controller;

public class UserControllerTests
{
    [Fact]
    public async Task GET_user_by_id()
    {
        // Arrange
        await using CustomWebApplicationFactory<Program> application = new CustomWebApplicationFactory<Program>();
        using HttpClient client = application.CreateClient();
        
        // Act
        var response = await client.GetAsync("/user/1");
        
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}