namespace LectorNet.UI.Common;

public record ErrorResponse(
    string? Type,
    string? Title,
    int Status,
    string? Detail,
    Dictionary<string, List<string>> Errors,
    string? TraceId);