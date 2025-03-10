using AirBelgie.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirBelgie.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    private readonly ILogger<TestController> _logger;
    private readonly ITestRepository _repository;
    
    public TestController(ILogger<TestController> logger, ITestRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    [HttpGet(Name = "GetTest")]
    public string Get()
    {
        _logger.LogTrace("Trace"); // Not outputted in Console
        _logger.LogDebug("Debug"); // Not outputted in Console
        _logger.LogInformation("Information"); // Not Outputted in Sentry
        _logger.LogWarning("Warning"); // Not Outputted in Sentry
        _logger.LogError("Error"); // Sentry and Console
        _logger.LogCritical("Critical"); // Sentry and Console
        throw new NotImplementedException();
        TestData schema = _repository.GetSchema();
        
        return schema.CurrentSchema;
    }
}