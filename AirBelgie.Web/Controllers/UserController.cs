using AirBelgie.Model;
using AirBelgie.Service;
using AirBelgie.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AirBelgie.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IKeyValService _keyValService;
    
    public UserController(IKeyValService keyValService, ILogger<UserController> logger, IUserService userService)
    {
        _keyValService = keyValService;
        _logger = logger;
        _userService = userService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        User? user = await _userService.GetByIdAsync(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        // @TODO Move these to a DTO where they can be validated
        User? existingUser = await _userService.GetByEmailAsync(user.Email!);
        if (existingUser != null)
        {
            return BadRequest("User with this email already exists");
        }
        
        // @TODO Move these to the service?
        user.Username = await Helpers.GenerateUsername(_keyValService);
        user.Password = PasswordHelper.HashPassword(user.Password!);
        
        User? createdUser = await _userService.CreateAsync(user);
        if (createdUser == null)
        {
            return BadRequest("Failed to create user");
        }
        
        return Ok(createdUser);
    }
}