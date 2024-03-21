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

public class Current
{
    public float Temp_C { get; set; }
    public float Temp_F { get; set; }
    public Condition Condition { get; set; } = new();
}

public class Condition
{
    public string Text { get; set; } = default!;
    public string Icon { get; set; } = default!;
}

public class CityDetail
{
    public string Name { get; set; } = default!;
    public string TempCondition { get; set; } = default!;
    public string Icon { get; set; } = default!;
    public string Time { get; set; } = default!;
    public string Date { get; set; } = default!;

}