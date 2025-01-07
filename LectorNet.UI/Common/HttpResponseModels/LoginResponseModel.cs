namespace LectorNet.UI.Common.HttpResponseModels;

public record LoginUserResponse(string FirstName, string LastName, string Email, string Role);