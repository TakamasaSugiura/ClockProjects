using System.IO.Abstractions;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace ClockCommonLib.Models;

public class DataFileModel : IDataFileModel
{
    private  JsonSerializerOptions JsonSerializerOptions { get; init; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() }
    };
    
    public T Load<T>(IFileInfo file)
    {
        var text = file.FileSystem.File.ReadAllText(file.FullName);
        if (IsYaml(file))
        {
            var deserializer = new Deserializer();
            return deserializer.Deserialize<T>(text);
        }

        return JsonSerializer.Deserialize<T>(text, JsonSerializerOptions) ?? throw new SerializationException();
    }

    public T LoadYaml<T>(Stream stream)
    {
        var deserializer = new Deserializer();
        using var reader = new StreamReader(stream);
        return deserializer.Deserialize<T>(reader);
    }

    public T LoadJson<T>(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream, JsonSerializerOptions) ?? throw new SerializationException();
    }
    
    public async Task<T> LoadAsync<T>(IFileInfo file, CancellationToken cancellationToken = default)
    {
        var text = await file.FileSystem.File.ReadAllTextAsync(file.FullName, cancellationToken);
        if (IsYaml(file))
        {
            var deserializer = new Deserializer();
            return deserializer.Deserialize<T>(text);
        }

        return JsonSerializer.Deserialize<T>(text, JsonSerializerOptions) ?? throw new SerializationException();
    }
    
    public void Save<T>(IFileInfo file, T data)
    {
        string text;
        if (IsYaml(file))
        {
            var serializer = new Serializer();
            text = serializer.Serialize(data);
        }
        else
        {
            text = JsonSerializer.Serialize(data, JsonSerializerOptions) ?? throw new SerializationException();
        }
        file.FileSystem.File.WriteAllText(file.FullName, text);
    }

    public void SaveYaml<T>(Stream stream, T data)
    {
        var serializer = new Serializer();
        using var writer = new StreamWriter(stream);
        serializer.Serialize(writer, data);
    }

    public void SaveJson<T>(Stream stream, T data)
    {
        JsonSerializer.Serialize(stream, data);
    }

    public async Task SaveAsync<T>(IFileInfo file, T data, CancellationToken cancellationToken = default)
    {
        string text;
        if (IsYaml(file))
        {
            var serializer = new Serializer();
            text = serializer.Serialize(data);
        }
        else
        {
            text = JsonSerializer.Serialize(data, JsonSerializerOptions) ?? throw new SerializationException();
        }
        await file.FileSystem.File.WriteAllTextAsync(file.FullName, text, cancellationToken);
    }

    private static bool IsYaml(IFileInfo fileInfo)
    {
        return fileInfo.Extension is ".yaml" or ".yml";
    }
}