using TimeZoneApp.Models;

namespace TimeZoneApp.Services;

public interface IAccountService
{
    UserInfo? Login(string username, string password);

    UserInfo? SignUp(string username, string email, string password);

    bool UserWithSameUserNameAlreadyExists(string username, string email);
}