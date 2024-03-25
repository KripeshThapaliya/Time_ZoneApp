using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeZoneApp.Models;
using TimeZoneApp.Services;

namespace TimeZoneApp.ViewModels;

public partial class HomePageViewModel : BaseViewModel
{
    
    [ObservableProperty]
    private IReadOnlyCollection<City> _homeCitiesSearch = [];

    [ObservableProperty]
    private City _homeCitySelectedKey = new();

    [ObservableProperty]
    private string _homeCitySearchText = string.Empty;

    [ObservableProperty]
    private bool _showHomeCityDetail = false;

    [ObservableProperty]
    private CityDetail _homeCityDetail = new();


    [ObservableProperty]
    private IReadOnlyCollection<City> _destinationCitiesSearch = [];

    [ObservableProperty]
    private City _destinationCitySelectedKey = new();

    [ObservableProperty]
    private string _destinationCitySearchText = string.Empty;

    [ObservableProperty]
    private bool _showDestinationCityDetail = false;

    [ObservableProperty]
    private CityDetail _destinationCityDetail = new();

    private readonly ITimeService _timeService;


}
