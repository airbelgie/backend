namespace AirBelgie.Tests;

public class DemoTest
{
    [Fact]
    public void Demo()
    {
        // Arrange
        int a = 1;
        int b = 1;
        int expectedResult = 2;

        // Act
        int actualResult = a + b;
        
        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}