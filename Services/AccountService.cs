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

    
    public UserInfo? Login(string username, string password)
    {
        return Connectivity.Current.NetworkAccess == NetworkAccess.Internet
            ? _users.FirstOrDefault(o =>
                (
                    o.UserName == username.ToLowerInvariant() ||
                    o.Email == username.ToLowerInvariant()
                ) &&
                o.Password == password.ToLowerInvariant())
            : null;
    }

}