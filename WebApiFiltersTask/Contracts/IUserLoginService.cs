using WebApiFiltersTask.Models;

namespace WebApiFiltersTask.Contracts;

public interface IUserLoginService
{
    Task<string> Login(UserLogin user);
    UserLogin GetUserByUserName(string email);
    void SaveChanges();
}
