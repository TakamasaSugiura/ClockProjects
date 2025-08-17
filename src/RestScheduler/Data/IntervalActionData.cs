namespace RestScheduler.Data;

public class IntervalActionData
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public RestData? RestData { get; set; }
    public int Interval { get; set; }
}