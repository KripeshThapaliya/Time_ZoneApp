using TimeZoneApp.ViewModels;
using TimeZoneApp.Views;

namespace TimeZoneApp;

public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel appShellViewModel)
    {
        InitializeComponent();
        this.BindingContext = appShellViewModel;
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}
