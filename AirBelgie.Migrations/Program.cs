// See https://aka.ms/new-console-template for more information

using System.Reflection;
using DbUp;
using DbUp.Engine;

Console.WriteLine("AirBelgie Database Migrations");
Console.WriteLine("----------------------------");

String connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                          ?? "Server=localhost;Port=5432;Database=airbelgie;User ID=airbelgie;Password=airbelgie;";

EnsureDatabase.For.PostgresqlDatabase(connectionString);

UpgradeEngine? upgrader = DeployChanges.To
    .PostgresqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .LogToConsole()
    .Build();

DatabaseUpgradeResult result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
    return 1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;