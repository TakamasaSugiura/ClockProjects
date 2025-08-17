using RestScheduler.Definitions;

namespace RestScheduler.Data;

public class RestData
{
    public string Url { get; set; } = string.Empty;
    public RestMethodType Method { get; set; } = RestMethodType.Get;
    public string ContentType { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public PlaceHolderType PlaceHolderType { get; set; } = PlaceHolderType.None;
    public Dictionary<string, string> Attributes { get; set; } = [];

    public RestData Clone()
    {
        return new RestData
        {
            Url = Url,
            Method = Method,
            ContentType = ContentType,
            Data = Data,
            PlaceHolderType = PlaceHolderType,
            Attributes = new Dictionary<string, string>(Attributes)
        };
    }
}