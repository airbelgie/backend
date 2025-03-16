using AirBelgie.Model;

namespace AirBelgie.Data;

public interface IUserRepository
{
    Task<User?> CreateUserAsync(User user);
    Task<bool> DeleteUserAsync(string id);
    Task<User?> GetUserByIdAsync(string id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByEmailOrUsernameAsync(string value);
    Task<User?> UpdateUserAsync(User user);
}