using ErrorOr;
using LectorNet.Application.Authentication.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Users;
using LectorNet.Application.Users.Common;
using LectorNet.Domain.Models.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LectorNet.Application.Authentication.Commands;

public class RegisterCommandHandler(
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork,
    IUsersRepository usersRepository,
    ILogger<RegisterCommandHandler> logger) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            logger.LogInformation("Registering new user with email : {Email}", command.Email);
            
            if (await usersRepository.ExistByEmailAsync(command.Email))
                return UserErrors.UserAlreadyExists;

            var hashPasswordResult = passwordHasher.HashPassword(command.Password);

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
            
            logger.LogInformation("Registered new user with email : {Email} successfully !", command.Email);

            return new AuthenticationResult(user);
        }
        catch (Exception e)
        {
            logger.LogError("Error registering new user with email {Email}: {ErrorMessage}", command.Email, e.Message);
            
            return Errors.UnexpectedError;
        }
    }
}
