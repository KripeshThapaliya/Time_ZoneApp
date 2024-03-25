using TimeZoneApp.Models;

namespace TimeZoneApp.Services;

public interface ITimeService
{
    IReadOnlyCollection<City> SearchCities(string searchText);
    CityTime GetTime(string city);
   
}
