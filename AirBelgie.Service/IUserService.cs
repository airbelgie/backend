using AirBelgie.Model;

namespace AirBelgie.Service;

public interface IUserService
{
    Task<User> GetById(string id);
}