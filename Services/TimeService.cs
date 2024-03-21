using Newtonsoft.Json;
using TimeZoneApp.Models;

namespace TimeZoneApp.Services;

public class TimeService : ITimeService
{
    private const string ApiKey = "7e507d9dcb934999be4165417241503";
    private const string SearchBaseAddress = "https://api.weatherapi.com/v1/search.json?q=";
    private const string GetTimeBaseAddress = "https://api.weatherapi.com/v1/current.json?q=";

    public IReadOnlyCollection<City> SearchCities(string searchText)
    {
        try
        {
            var client = new HttpClient();

            var url = $"{SearchBaseAddress}{searchText}&key={ApiKey}";

            var response = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<List<City>>(response);
            if (result != null) return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new City[] { };
    }

    public CityTime GetTime(string city)
    {
        try
        {
            var client = new HttpClient();

            var url = $"{GetTimeBaseAddress}{city}&key={ApiKey}";

            var response = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<CityTime>(response);
            if (result != null) return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new CityTime();
    }
}