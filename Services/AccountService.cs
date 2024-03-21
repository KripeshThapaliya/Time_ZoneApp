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

    public UserInfo? SignUp(string username, string email, string password)
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
        {
            var newUser = new UserInfo
            {
                Id = _users.Count + 1,
                UserName = username,
                Email = email,
                Password = password
            };

            _users.Add(newUser);

            return newUser;
        }
        return null;
    }
    public bool UserWithSameUserNameAlreadyExists(string username, string email)
    {
        return Connectivity.Current.NetworkAccess != NetworkAccess.Internet || _users.Any(o =>
        (
            o.UserName == username.ToLowerInvariant() ||
            o.Email == email.ToLowerInvariant()
        ));
    }

}