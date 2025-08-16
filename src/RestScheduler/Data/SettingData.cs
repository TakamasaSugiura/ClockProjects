namespace RestScheduler.Data;

/// <summary>
/// 設定データ
/// </summary>
public class SettingData
{
    public string Version { get; set; } = string.Empty;
    public IntervalActionData[] IntervalActionList { get; set; } = [];
}