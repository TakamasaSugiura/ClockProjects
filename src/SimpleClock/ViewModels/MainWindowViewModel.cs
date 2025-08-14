using System.Collections.ObjectModel;
using ClockCommonLib.ViewModels;

namespace SimpleClock.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ClockElementViewModel> Clocks { get; } = [];
    public string Greeting { get; } = "Welcome to Avalonia!";

    public MainWindowViewModel()
    {
        var localTimeClock = new ClockElementViewModel
        {
            Name = "Local",
            Value = "",
            OnTickFunction = () => $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
        };
        var utcTimeClock = new ClockElementViewModel
        {
            Name = "UTC",
            Value = "",
            OnTickFunction = () => $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}"
        };
        Clocks.Add(localTimeClock);
        Clocks.Add(utcTimeClock);
        foreach (var clock in Clocks)
        {
            clock.Start();
        }
    }
}