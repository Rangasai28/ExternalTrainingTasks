using WebApiFiltersTask.Models;

namespace WebApiFiltersTask.Contracts;

public interface IUserService
{
    Task<string> Login(User newUser);
    Task<IEnumerable<User>> GetUsers();
    Task<(bool, IEnumerable<User>)> GetAllUsers();
}
