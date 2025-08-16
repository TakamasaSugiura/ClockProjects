using System.IO.Abstractions;
using ClockCommonLib.Models;
using RestScheduler.Data;

namespace RestScheduler.Models;

public class FileIoModel : IFileIoModel
{
    private readonly IDataFileModel _dataFileModel;

    public FileIoModel(IDataFileModel dataFileModel)
    {
        _dataFileModel = dataFileModel;
    }
    
    public SettingData OpenSettingFile(Stream stream)
    {
        return _dataFileModel.LoadJson<SettingData>(stream);
    }

    public void SaveSettingFile(Stream stream, SettingData data)
    {
        _dataFileModel.SaveJson(stream, data);
    }
}