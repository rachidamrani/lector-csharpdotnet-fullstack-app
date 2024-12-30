using FluentValidation;

namespace LectorNet.Application.Authentication.Queries;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage("L'adresse e-mail est requise")
            .EmailAddress()
            .WithMessage("L'adresse e-mail est invalide");

        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage("Le mot de passe est requis");
    }
}