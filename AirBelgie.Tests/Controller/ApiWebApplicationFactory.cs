using AirBelgie.Service;
using AirBelgie.Tests.Controller.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace AirBelgie.Tests.Controller;

using Microsoft.AspNetCore.Mvc.Testing;
 
public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Is be called after the `ConfigureServices` from the Startup
        // which allows you to overwrite the DI with mocked instances
        builder.ConfigureTestServices(services =>
        {
            services.AddTransient<IUserService, UserServiceMock>();
        });
    }
}