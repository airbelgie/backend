using AirBelgie.Model;
using AirBelgie.Service;

namespace AirBelgie.Tests.Controller.Mocks;

public class UserServiceMock : IUserService
{
    public Task<User> GetById(string id)
    {
        return Task.FromResult(new User { Id = Guid.NewGuid(), Username = "test", Password = "test", Email = "test"});
    }
}