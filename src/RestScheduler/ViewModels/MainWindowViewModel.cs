using System.Collections.ObjectModel;
using System.IO.Abstractions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using ClockCommonLib.ViewModels;
using CommunityToolkit.Mvvm.Input;
using RestScheduler.Data;
using RestScheduler.Models;

namespace RestScheduler.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IFileSystem _fileSystem;
    private readonly IFileIoModel _fileIoModel;
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

    public ObservableCollection<IntervalActionData> IntervalDataList { get; } = [];

    public MainWindowViewModel(IFileSystem fileSystem, IFileIoModel fileIoModel)
    {
        _fileSystem = fileSystem;
        _fileIoModel = fileIoModel;
    }
    
    [RelayCommand]
    private void NewMenuAction()
    {
        IntervalDataList.Clear();
    }

    [RelayCommand]
    private async Task OpenMenuActionAsync(object obj)
    {
        if (obj is Window window)
        {
            var toplevel = TopLevel.GetTopLevel(window);
            var files = await toplevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions());
            if (files.Count == 1)
            {
                await using var stream = await files.Single().OpenReadAsync();
                var settingData = _fileIoModel.OpenSettingFile(stream);
                IntervalDataList.Clear();
                foreach (var intervalActionData in settingData.IntervalActionList)
                {
                    IntervalDataList.Add(intervalActionData);
                }
            }
        }
    }

    [RelayCommand]
    private async Task SaveMenuAction(object obj)
    {
        if (obj is Window window)
        {
            var toplevel = TopLevel.GetTopLevel(window);
            var file = await toplevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions());
            if (file is not null)
            {
                await using var stream = await file.OpenWriteAsync();
                var settingData = new SettingData
                {
                    IntervalActionList = [..IntervalDataList]
                };
                _fileIoModel.SaveSettingFile(stream, settingData);
            }
        }
    }

    [RelayCommand]
    private void ExitMenuAction(object obj)
    {
        if (obj is Window window)
        {
            window.Close();
        }
    }

    [RelayCommand]
    private void AddIntervalAction()
    {
        IntervalDataList.Add(new IntervalActionData());
    }
}