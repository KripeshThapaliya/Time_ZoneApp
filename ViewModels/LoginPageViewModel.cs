using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using TimeZoneApp.Services;
using TimeZoneApp.UserControl;
using TimeZoneApp.Views;

namespace TimeZoneApp.ViewModels;

public partial class LoginPageViewModel(IAccountService accountService) : BaseViewModel
{
}