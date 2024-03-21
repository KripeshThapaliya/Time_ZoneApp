using TimeZoneApp.ViewModels;

namespace TimeZoneApp.Views;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel _homePageViewModel;

    public HomePage(HomePageViewModel homePageViewModel)
    {
        InitializeComponent();
        _homePageViewModel = homePageViewModel;
        BindingContext = homePageViewModel;
    }

    private void Cities_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        _homePageViewModel.HomeCitySelected();
    }

    private void DestinationCitiesSearch_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        _homePageViewModel.DestinationCitySelected();
    }
}