using System.Security.Claims;
using LectorNet.Contracts.Authentication;
using LectorNet.UI.Authentication;
using LectorNet.UI.Services.Interfaces;
using LectorNet.UI.ViewModels;

namespace LectorNet.UI.Services;

public class AuthService(HttpClient httpClient) : IAuthService
{
    // sprivate const string ApiUrl = "http://localhost:5013/api/auth";
    
    // For docker usage only 
    private const string ApiUrl = "http://backend:8080/api/auth";
    public async Task<HttpResponseMessage> Login(LoginUserModel loginUserModel)
    {
        return await httpClient.PostAsJsonAsync($"{ApiUrl}/login", loginUserModel);
    }

    public async Task<HttpResponseMessage> Register(RegisterUserModel registerUserModel)
    {
        return await httpClient.PostAsJsonAsync($"{ApiUrl}/register", registerUserModel);
    }

    public ClaimsPrincipal UserToClaims(AuthenticationResponse authenticationResponse)
    {
        var claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, authenticationResponse!.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{authenticationResponse!.FirstName} {authenticationResponse.LastName}"),
            new Claim(ClaimTypes.Role, authenticationResponse.Role)
        };

        var identity = new ClaimsIdentity(claims, AuthConstants.AuthScheme);
        var principal = new ClaimsPrincipal(identity);
        
        return principal;
    }
}