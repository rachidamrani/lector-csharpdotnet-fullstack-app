using ErrorOr;
using LectorNet.Application.Authentication.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Users;
using LectorNet.Domain.Models.Users;
using MediatR;

namespace LectorNet.Application.Authentication.Commands;

public class RegisterCommandHandler(
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork,
    IUsersRepository usersRepository
) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            if (await usersRepository.ExistByEmailAsync(command.Email))
                return AuthenticationErrors.UserAlreadyExists;

            ErrorOr<string> hashPasswordResult = passwordHasher.HashPassword(command.Password);

            if (hashPasswordResult.IsError)
                return hashPasswordResult.Errors;

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = hashPasswordResult.Value,
            };

            await usersRepository.AddAsync(user);
            await unitOfWork.CommitChangesAsync();

            return new AuthenticationResult(user);
        }
        catch (Exception)
        {
            return Errors.UnexpectedError;
        }
    }
}
