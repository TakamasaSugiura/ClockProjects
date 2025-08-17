using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using RestScheduler.Data;
using RestScheduler.Definitions;

namespace RestScheduler.ViewModels;

public partial class IntervalContentViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Interval { get; set; } = 10;
    public bool IsWorking { get; set; }
    public RestData RestData { get; set; } = new();

    public RestMethodType[] RestMethods { get; } = Enum.GetValues<RestMethodType>();
    
    private readonly DispatcherTimer _timer = new();
    
    [RelayCommand]
    private async Task WorkButtonActionAsync()
    {
        if (IsWorking)
        {
            Start();
        }
        else
        {
            Stop();
        }
    }

    private void Start()
    {
        _timer.Interval = TimeSpan.FromMilliseconds(Interval);
        _timer.Start();
    }

    private void Stop()
    {
        _timer.Stop();
    }
}