namespace LectorNet.UI.Common;

public class ErrorResponse
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    int Status { get; set; }
    public string? Detail { get; set; }
    public string? TraceId { get; set; }
}
