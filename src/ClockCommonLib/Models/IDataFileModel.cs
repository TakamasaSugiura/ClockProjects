using System.IO.Abstractions;

namespace ClockCommonLib.Models;

public interface IDataFileModel
{
    T Load<T>(IFileInfo file);
    T LoadYaml<T>(Stream stream);
    T LoadJson<T>(Stream stream);
    Task<T> LoadAsync<T>(IFileInfo file, CancellationToken cancellationToken = default);
    void Save<T>(IFileInfo file, T data);
    void SaveYaml<T>(Stream stream, T data);
    void SaveJson<T>(Stream stream, T data);
    Task SaveAsync<T>(IFileInfo file, T data, CancellationToken cancellationToken = default);
}