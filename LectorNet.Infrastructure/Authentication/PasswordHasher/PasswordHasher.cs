using System.Text.RegularExpressions;
using ErrorOr;
using LectorNet.Application.Common.Interfaces;

namespace LectorNet.Infrastructure.Authentication.PasswordHasher;

public class PasswordHasher : IPasswordHasher
{
    private readonly Regex _passwordRegex = StrongPasswordRegex();

    public bool IsCorrectPassword(string password, string hash) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hash);

    public ErrorOr<string> HashPassword(string password)
    {
        return !_passwordRegex.IsMatch(password)
            ? Error.Validation(description: "Mot de passe faible !")
            : BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    private static Regex StrongPasswordRegex()
    {
        return new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
    }
}
