using AirBelgie.Model;

namespace AirBelgie.Data;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(string id);
}