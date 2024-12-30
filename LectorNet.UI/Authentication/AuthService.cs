using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace LectorNet.UI.Authentication;

public class AuthService(AuthenticationStateProvider authenticationStateProvider)
{
    private async Task<AuthenticationState> GetAuthState()
    {
        return await authenticationStateProvider.GetAuthenticationStateAsync();
    }

    public async Task<bool> UserIsAuthenticated()
    {
        var authState = await GetAuthState();
        return authState.User.Identity != null && authState.User.Identity.IsAuthenticated;
    }

    public async Task<ClaimsPrincipal> GetConnectedUser()
    {
        var authState = await GetAuthState();
        return authState.User;
    }

    public async Task<string?> GetConnectedUserId()
    {
        var authState = await GetAuthState();
        return authState
            .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
            ?.Value;
    }
}
