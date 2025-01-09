using ErrorOr;
using FluentAssertions;
using LectorNet.Application.Authentication.Commands;
using LectorNet.Application.Authentication.Common;
using LectorNet.Application.Common;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Users;
using LectorNet.Application.Users.Common;
using LectorNet.Domain.Models.Users;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LectorNet.Unit.Tests.Authentication;

public class RegisterCommandHandlerTests
{
    private readonly RegisterCommandHandler _sut;
    private readonly IUsersRepository _usersRepository = Substitute.For<IUsersRepository>();
    private readonly IPasswordHasher _passwordHasher = Substitute.For<IPasswordHasher>();
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly ILogger<RegisterCommandHandler> _logger = Substitute.For<ILogger<RegisterCommandHandler>>();
    
    public RegisterCommandHandlerTests()
    { 
        _sut = new RegisterCommandHandler(
            _passwordHasher, 
            _unitOfWork, 
            _usersRepository, 
            _logger);
    }
    
    [Fact]
    public async Task Handle_ShouldReturnRegisteredUser_WhenAllUsersInformationsProvidedAreValidAndUserDoesNotExist()
    {
        // Arrange
        // All user's infos are valid
        var command = new RegisterCommand("John","Doe", "johnedoe@example.com", "Pass123@@"); 
        var hashedPassword = _passwordHasher.HashPassword(command.Password);
        
        var user = new User
        {
            FirstName = command.FirstName, 
            LastName = command.LastName, 
            Email = command.Email, 
            Password = hashedPassword.Value
        };

        _usersRepository.AddAsync(user).Returns(Task.CompletedTask);
        _usersRepository.ExistByEmailAsync(command.Email).Returns(false);
        
        // Act
        var result = (await _sut.Handle(command, CancellationToken.None)).Value;

        // Assert
        result.Should().BeEquivalentTo(new AuthenticationResult(user));
    }
    
    [Fact]
    public async Task Handle_ShouldNotRegisterUser_WhenUsersInformationsProvidedWithWeakPassword()
    {
        // Arrange
        var command = new RegisterCommand("John","Doe", "johnedoe@example.com", "weakpass");
        _usersRepository.ExistByEmailAsync(command.Email).Returns(false);
        _passwordHasher.HashPassword(command.Password)
            .Returns(Error.Validation(description: "Mot de passe faible !"));
        
        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        result.FirstError.Should().Be(Error.Validation(description: "Mot de passe faible !"));
    }
    
    [Fact]
    public async Task Handle_ShouldReturnUserAlreadyExistsError_WhenUserAlreadyExists()
    {
        // Arrange
        var command = new RegisterCommand("John","Doe", "johnedoe@example.com", "Pass123@@");
        _usersRepository.ExistByEmailAsync(command.Email).Returns(true);
        
        // Act
        var result = await _sut.Handle(command, CancellationToken.None);

        // Assert
        result.FirstError.Should().Be(UserErrors.UserAlreadyExists);
    }

    [Fact]
    public async Task Handle_ShouldReturnUnexpectedError_WhenRegistringUserFails()
    {
        // Arrange
        var command = new RegisterCommand("John","Doe", "johnedoe@example.com", "Pass123@@");
        _usersRepository.ExistByEmailAsync(command.Email).Returns(false);
        
        _usersRepository.AddAsync(Arg.Any<User>())
            .Returns(Task.FromException(new Exception()));
        
        // Act
        var result = (await _sut.Handle(command, CancellationToken.None)).FirstError;
        
        // Assert
        result.Should().Be(Errors.UnexpectedError);
    }
}