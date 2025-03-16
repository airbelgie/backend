using AirBelgie.Data;
using AirBelgie.Model;

namespace AirBelgie.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User?> CreateAsync(User user)
    {
        return await _userRepository.CreateUserAsync(user);
    }
    
    public async Task<bool> DeleteAsync(string id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
    
    public async Task<User?> GetByIdAsync(string id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }
    
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }
    
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _userRepository.GetUserByUsernameAsync(username);
    }
    
    public async Task<User?> GetByEmailOrUsernameAsync(string value)
    {
        return await _userRepository.GetUserByEmailOrUsernameAsync(value);
    }
    
    public async Task<User?> UpdateAsync(User user)
    {
        return await _userRepository.UpdateUserAsync(user);
    }
}