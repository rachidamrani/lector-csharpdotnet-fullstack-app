using System.Security.Claims;
using LectorNet.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace LectorNet.UI.Services;

public class ApiService(HttpClient httpClient, AuthenticationStateProvider authProvider) : IApiService
{
    // private const string ApiUrl = "http://localhost:5013/api/";

    // For docker usage only
    private const string ApiUrl = "http://backend:8080/api/";

    public async Task<string?> GetAuthState()
    {
        var state = await authProvider.GetAuthenticationStateAsync();
        var user = state.User;

        return user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    public async Task<string?> GetUserName()
    {
        var state = await authProvider.GetAuthenticationStateAsync();
        var user = state.User;
        
        return user?.FindFirst(ClaimTypes.Name)?.Value;
    }

    public async Task AddUserIdToRequestHeaders()
    {
        var userId = await GetAuthState();

        if (!string.IsNullOrEmpty(userId))
        {
            httpClient.DefaultRequestHeaders.Add("X-User-Id", userId);
        }
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string endPoint, T content)
    {
        await AddUserIdToRequestHeaders();
        return await httpClient.PostAsJsonAsync($"{ApiUrl}{endPoint}", content);
    }

    public async Task<HttpResponseMessage> GetAsync(string endPoint)
    {
        await AddUserIdToRequestHeaders();
        return await httpClient.GetAsync($"{ApiUrl}{endPoint}");
    }

    public async Task<HttpResponseMessage> DeleteAsync<T>(string endPoint, T content)
    {
        throw new NotImplementedException();
    }
}