using Avalonia.Threading;

namespace ClockCommonLib.ViewModels;

public class ClockElementViewModel : ContentElementViewModel, IDisposable
{
    private readonly DispatcherTimer _timer = new(){ Interval = TimeSpan.FromMicroseconds(100) };

    public Func<string> OnTickFunction { get; set; } = () => string.Empty;

    public TimeSpan Interval
    {
        get => _timer.Interval;
        set => _timer.Interval = value;
    }
    
    public ClockElementViewModel()
    {
        _timer.Tick += TimerOnTick;
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }
    
    private void TimerOnTick(object? sender, EventArgs e)
    {
        Value = OnTickFunction.Invoke();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Stop();
            _timer.Tick -= TimerOnTick;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}