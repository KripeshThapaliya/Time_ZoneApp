using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using TimeZoneApp.Services;
using TimeZoneApp.UserControl;
using TimeZoneApp.Views;

namespace TimeZoneApp.ViewModels;

public partial class LoginPageViewModel(IAccountService accountService) : BaseViewModel
{
     [ObservableProperty]
    private string _userName = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [RelayCommand]
    public async Task Login()
    {
        if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
        {
            var userInfo = accountService.Login(UserName, Password);

            if (userInfo != null)
            {
                if (Preferences.ContainsKey(nameof(App.UserInfo)))
                {
                    Preferences.Remove(nameof(App.UserInfo));
                }

                var userDetails = JsonConvert.SerializeObject(userInfo);
                Preferences.Set(nameof(App.UserInfo), userDetails);
                App.UserInfo = userInfo;

                Shell.Current.FlyoutHeader = new FlyoutHeaderControl();
                ResetInputs();

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Invalid Credentials", "OKAY");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "All fields are required", "OKAY");
        }
    }

    [RelayCommand]
    public async Task GoToSignUpPage()
    {
        ResetInputs();
        await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
    }

    private void ResetInputs()
    {
        UserName = string.Empty;
        Password = string.Empty;
    }

}