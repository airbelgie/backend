using AirBelgie.Data;
using AirBelgie.Service;
using Microsoft.AspNetCore.Mvc;

namespace AirBelgie.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController
{
    private readonly ILogger<TestController> _logger;
    private readonly ITestRepository _repository;
    private readonly IEmailService _emailService;
    
    public TestController(ILogger<TestController> logger, ITestRepository repository, IEmailService emailService)
    {
        _logger = logger;
        _repository = repository;
        _emailService = emailService;
    }
    
    [HttpGet(Name = "GetTest")]
    public string Get()
    {
        TestData schema = _repository.GetSchema();
        
        return schema.CurrentSchema;
    }
    
    [HttpGet("email")]
    public string SendEmail()
    {
        _emailService.SendEmail("Ray Parkar", "rahul.a.parkar@gmail.com", "Test Email", "<h1>Test Email</h1>", "Test Email");
        return "Email sent";
    }
}