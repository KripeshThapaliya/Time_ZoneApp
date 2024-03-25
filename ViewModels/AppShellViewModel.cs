using CommunityToolkit.Mvvm.Input;

namespace TimeZoneApp.ViewModels;
public partial class AppShellViewModel : BaseViewModel
{
    [RelayCommand]
    async void SignOut()
    {
        if (Preferences.ContainsKey(nameof(App.UserInfo)))
        {
            Preferences.Remove(nameof(App.UserInfo));
        }

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
   
}
