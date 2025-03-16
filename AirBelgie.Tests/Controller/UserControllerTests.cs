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
        var response = await client.GetAsync("/user/b8c8637b-acd4-4f68-9b06-0c0904737568");
        
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}