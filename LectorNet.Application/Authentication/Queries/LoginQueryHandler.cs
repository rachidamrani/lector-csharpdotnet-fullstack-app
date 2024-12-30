using ErrorOr;
using LectorNet.Application.Authentication.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Users;
using MediatR;

namespace LectorNet.Application.Authentication.Queries;

public class LoginQueryHandler(IPasswordHasher passwordHasher, IUsersRepository usersRepository)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        LoginQuery query,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var user = await usersRepository.GetByEmailAsync(query.Email);

            if (user is null)
                return AuthenticationErrors.UserNotFound;

            var passwordIsCorrect = passwordHasher.IsCorrectPassword(query.Password, user.Password);

            if (!passwordIsCorrect)
                return AuthenticationErrors.InvalidCredentials;

            return new AuthenticationResult(user);
        }
        catch (Exception)
        {
            return Errors.UnexpectedError;
        }
    }
}
