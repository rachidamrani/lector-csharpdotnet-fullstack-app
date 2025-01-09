using ErrorOr;
using LectorNet.Application.Authentication.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Users;
using LectorNet.Application.Users.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Authentication.Queries;

public class LoginQueryHandler(
    IPasswordHasher passwordHasher,
    IUsersRepository usersRepository,
    ILogger<LoginQueryHandler> logger)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery query,
        CancellationToken cancellationToken
    )
    {
        try
        {
            logger.LogInformation("User with email {Email} is logging in.", query.Email);
            
            var user = await usersRepository.GetByEmailAsync(query.Email);

            if (user is null)
                return UserErrors.UserNotFound;

            var passwordIsCorrect = passwordHasher.IsCorrectPassword(query.Password, user.Password);

            if (!passwordIsCorrect)
                return AuthenticationErrors.InvalidCredentials;
            
            logger.LogInformation("User with email {Email} logged in successfully!", query.Email);

            return new AuthenticationResult(user);
        }
        catch (Exception e)
        {
            logger.LogError("Error logging user with email {Email}: {ErrorMessage}", 
                query.Email, e.Message);

            return Errors.UnexpectedError;
        }
    }
}
