namespace LectorNet.UI.Services.Interfaces;

public interface IAuthService
{
    Task Login(User user);
    Task Register(string firstName, string lastName, string email, string password);
}