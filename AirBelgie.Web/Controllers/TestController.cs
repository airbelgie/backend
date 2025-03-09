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
        TestData schema = _repository.GetSchema();
        
        return schema.CurrentSchema;
    }
}