namespace AirBelgie.Shared.DTOs;

public class Login
{
    public string? Username { get; set; }
    public required string Password { get; set; }
}

public class Register
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Username { get; set; }
}