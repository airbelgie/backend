using AirBelgie.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirBelgie.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    private readonly ILogger<TestController> _logger;
    
    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "GetTest")]
    public string Get()
    {
        TestRepository repository = new TestRepository();

        TestData schema = repository.GetSchema();
        
        return schema.CurrentSchema;
    }
}