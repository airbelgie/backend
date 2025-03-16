using AirBelgie.Model;
using AirBelgie.Service;

namespace AirBelgie.Tests.Controller.Mocks;

public class UserServiceMock : IUserService
{
    private readonly List<User> _users = new List<User>()
    {
        new User { Id = Guid.Parse("b8c8637b-acd4-4f68-9b06-0c0904737568"), Username = "test", Password = "test", Email = "test@example.com" }
    };
    
    public Task<User?> GetByIdAsync(string id)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Id == Guid.Parse(id)));
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Email == email));
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Username == username));
    }

    public Task<User?> GetByEmailOrUsernameAsync(string value)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Email == value));
    }

    public Task<User?> CreateAsync(User user)
    {
        if (_users.Any(u => u.Username == user.Username || u.Email == user.Email || u.Id == user.Id))
        {
            return Task.FromResult<User?>(null);
        }
        
        _users.Add(user);
        return Task.FromResult(user)!;
    }

    public Task<User?> UpdateAsync(User user)
    {
        User? existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser == null)
        {
            return Task.FromResult<User?>(null);
        }
        
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        
        return Task.FromResult(existingUser)!;
    }

    public Task<bool> DeleteAsync(string id)
    {
        User? exitingUser = _users.FirstOrDefault(u => u.Id == Guid.Parse(id));
        if (exitingUser == null)
        {
            return Task.FromResult(false);
        }
        
        _users.Remove(exitingUser);
        return Task.FromResult(true);
    }
}