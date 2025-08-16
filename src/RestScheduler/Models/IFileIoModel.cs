using System.IO.Abstractions;
using RestScheduler.Data;

namespace RestScheduler.Models;

public interface IFileIoModel
{
    SettingData OpenSettingFile(Stream stream);
    void SaveSettingFile(Stream stream, SettingData data);
}