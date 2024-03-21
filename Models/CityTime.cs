namespace TimeZoneApp.Models;

public class CityTime
{
    public Location Location { get; set; } = new();
    public Current Current { get; set; } = new();
}

public class Location
{
    public string Name { get; set; } = default!;
    public DateTime LocalTime { get; set; }
}