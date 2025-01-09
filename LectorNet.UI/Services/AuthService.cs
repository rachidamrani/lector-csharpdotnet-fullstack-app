using System.Security.Claims;
using LectorNet.UI.Authentication;
using LectorNet.UI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace LectorNet.UI.Services;

public class AuthService(IHttpContextAccessor httpContextAccessor, AuthenticationStateProvider authenticationStateProvider) : IAuthService
{
    public async Task Login(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Firstname),
            new(ClaimTypes.Name, $"{user.Firstname} {user.Lastname}"),
            new(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, AuthConstants.AuthScheme);
        var principal = new ClaimsPrincipal(identity);
        var authProperties = new AuthenticationProperties { IsPersistent = true };

        if (httpContextAccessor.HttpContext != null)
            await httpContextAccessor.HttpContext.SignInAsync(
                AuthConstants.AuthScheme, principal, authProperties);
    }

    public async Task Register(string firstName, string lastName, string email, string password)
    {
        throw new NotImplementedException();
    }
}