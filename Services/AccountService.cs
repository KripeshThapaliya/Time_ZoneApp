using TimeZoneApp.Models;

namespace TimeZoneApp.Services;

public class AccountService : IAccountService
{
  private readonly List<UserInfo> _users = [];

    public AccountService()
    {
        if (_users.Count != 0) return;
        var user = new UserInfo()
        {
            Id = 1,
            UserName = "admin",
            Email = "admin@timezoneapp.com",
            Password = "12345"
        };
        _users.Add(user);
    }

}