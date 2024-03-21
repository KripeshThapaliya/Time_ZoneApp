using TimeZoneApp.ViewModels;

namespace TimeZoneApp;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel loginPageViewModel)
    {
        InitializeComponent();
        this.BindingContext = loginPageViewModel;
    }
}