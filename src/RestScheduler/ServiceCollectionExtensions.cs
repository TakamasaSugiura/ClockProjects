using System.IO.Abstractions;
using ClockCommonLib.Models;
using Microsoft.Extensions.DependencyInjection;
using RestScheduler.Models;
using RestScheduler.ViewModels;

namespace RestScheduler;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        //collection.AddSingleton<IRepository, Repository>();
        //collection.AddTransient<BusinessService>();
        collection.AddSingleton<IFileSystem, FileSystem>();
        collection.AddSingleton<IDataFileModel, DataFileModel>();
        collection.AddSingleton<IFileIoModel, FileIoModel>();
        collection.AddTransient<MainWindowViewModel>();
    }
}