using WebApiAutenticationDemo.Models;
namespace WebApiAutenticationDemo.Contracts;

public interface IUserService
{
    Task<string> Login(User newUser);
    Task<IEnumerable<User>> GetUsers();

}
