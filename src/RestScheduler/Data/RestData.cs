using RestScheduler.Definitions;

namespace RestScheduler.Data;

public class RestData
{
    public string Id { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public RestMethodType Method { get; set; } = RestMethodType.Get;
    public string ContentType { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public PlaceHolderType PlaceHolderType { get; set; } = PlaceHolderType.None;
    public Dictionary<string, string> Attributes { get; set; } = [];
}