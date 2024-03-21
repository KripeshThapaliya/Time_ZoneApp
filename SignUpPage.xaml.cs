using TimeZoneApp.ViewModels;

namespace TimeZoneApp;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpPageViewModel signUpPageViewModel)
    {
        InitializeComponent();
        BindingContext = signUpPageViewModel;
    }
}