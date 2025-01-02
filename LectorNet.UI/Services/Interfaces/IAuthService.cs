using System.Security.Claims;
using LectorNet.Contracts.Authentication;
using LectorNet.UI.ViewModels;

namespace LectorNet.UI.Services.Interfaces;

public interface IAuthService
{
    Task<HttpResponseMessage> Login(LoginUserModel registerUserUserModel);
    Task<HttpResponseMessage> Register(RegisterUserModel registerUserModel);
    ClaimsPrincipal UserToClaims(AuthenticationResponse authenticationResponse);
}