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

    /// <inheritdoc/>
    public HomePageViewModel(ITimeService timeService)
    {
        _timeService = timeService;
        HomeCitiesSearch = [];
        HomeCitySelectedKey = new();
        HomeCitySearchText = string.Empty;
        ShowHomeCityDetail = false;
        HomeCityDetail = new();

        DestinationCitiesSearch = [];
        DestinationCitySelectedKey = new();
        DestinationCitySearchText = string.Empty;
        ShowDestinationCityDetail = false;
        DestinationCityDetail = new();
    }

    [RelayCommand]
    void SearchHomeCities(string query)
    {
        if (query.Length < 4) { return; }

        ShowHomeCityDetail = false;
        try
        {
            var result = _timeService.SearchCities(query);

            HomeCitiesSearch = result;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    [RelayCommand]
    void SearchDestinationCities(string query)
    {
        if (query.Length < 4) { return; }

        ShowDestinationCityDetail = false;
        try
        {
            var result = _timeService.SearchCities(query);

            DestinationCitiesSearch = result;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

     public void HomeCitySelected()
    {
        HomeCitiesSearch = [];
        ShowHomeCityDetail = false;
        try
        {
            var result = _timeService.GetTime(HomeCitySelectedKey.Name);

            HomeCityDetail = ConvertToCityDetail(result);
            HomeCitySearchText = string.Empty;
            ShowHomeCityDetail = true;
            ShowDestinationCityDetail = true;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    private CityDetail ConvertToCityDetail(CityTime result)
    {
        return new CityDetail
        {
            Name = result.Location.Name,
            TempCondition = $"{result.Current.Temp_F}°F, {result.Current.Condition.Text}",
            Icon = $"https:{result.Current.Condition.Icon}",
            Time = result.Location.LocalTime.ToString("hh:mm tt"),
            Date = result.Location.LocalTime.ToString("d")
        };
    }

    public void DestinationCitySelected()
    {
        DestinationCitiesSearch = [];
        ShowDestinationCityDetail = false;
        try
        {
            var result = _timeService.GetTime(DestinationCitySelectedKey.Name);

            DestinationCityDetail = ConvertToCityDetail(result);
            DestinationCitySearchText = string.Empty;
            ShowDestinationCityDetail = true;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}
