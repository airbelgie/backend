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
    
    public async Task<User> GetById(string id)
    {
        User? user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }
}