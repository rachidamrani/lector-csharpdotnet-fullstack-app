namespace LectorNet.UI.Services.Interfaces;

public interface IApiService
{
    Task<string?> GetAuthState();
    Task AddUserIdToRequestHeaders();
    Task<HttpResponseMessage> PostAsync<T>(string endPoint, T content);
}