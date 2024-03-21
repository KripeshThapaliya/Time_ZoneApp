using TimeZoneApp.Models;
using TimeZoneApp.ViewModels;

namespace TimeZoneApp;

public partial class App : Application
{
    public static UserInfo? UserInfo;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell(new AppShellViewModel());
    }
}
