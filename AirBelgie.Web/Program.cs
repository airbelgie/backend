using AirBelgie.Data;
using AirBelgie.Service;

var builder = WebApplication.CreateBuilder(args);

// Add environment variables to configuration
builder.Configuration.AddEnvironmentVariables(prefix: "AirBelgie_");

// configure strongly typed settings object
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

// Configure DI for application services
builder.Services.AddSingleton<DatabaseContext>();

// Configure DI for repositories
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Configure DI for services
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }