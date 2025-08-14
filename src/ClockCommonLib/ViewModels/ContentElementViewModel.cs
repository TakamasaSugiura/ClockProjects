using CommunityToolkit.Mvvm.ComponentModel;

namespace ClockCommonLib.ViewModels;

public partial class ContentElementViewModel : ObservableObject
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _value = string.Empty;
}