using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeZoneApp.Services;

namespace TimeZoneApp.ViewModels;
public partial class SignUpPageViewModel(IAccountService accountService) : BaseViewModel
{
    [ObservableProperty]
    private string _userName = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private string _verifyPassword = string.Empty;

    [RelayCommand]
    public async Task SignUp()
    {
        if (IsModelValid())
        {
            if (Password != VerifyPassword)
            {
                await Shell.Current.DisplayAlert("Error", "Passwords do not match", "OKAY");
                return;
            }

            var userAlreadyExists = accountService.UserWithSameUserNameAlreadyExists(UserName, Email);

            if (userAlreadyExists)
            {
                await Shell.Current.DisplayAlert("Error", "User with same username or email already exists", "OKAY");
                return;
            }

            accountService.SignUp(UserName, Email, Password);

            ResetInputs();

            await Shell.Current.DisplayAlert("Success", "User registered successfully", "OKAY");

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "All fields are required", "OKAY");
        }
    }

    [RelayCommand]
    public async Task BackToLoginPage()
    {
        ResetInputs();
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private bool IsModelValid()
    {
        return !string.IsNullOrWhiteSpace(UserName) &&
               !string.IsNullOrWhiteSpace(Email) &&
               !string.IsNullOrWhiteSpace(Password) &&
               !string.IsNullOrWhiteSpace(VerifyPassword);
    }

    private void ResetInputs()
    {
        UserName = string.Empty;
        Email = string.Empty;
        UserName = string.Empty;
        VerifyPassword = string.Empty;
    }
}
