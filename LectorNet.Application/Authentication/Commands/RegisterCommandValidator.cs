using System.Text.RegularExpressions;
using FluentValidation;

namespace LectorNet.Application.Authentication.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(command => command.FirstName)
            .NotEmpty()
            .WithMessage("Le prénom est requis")
            .MinimumLength(3)
            .WithMessage("Le prénom doit comporter au moins 3 caractères");

        RuleFor(command => command.LastName)
            .NotEmpty()
            .WithMessage("Le nom est requis")
            .MinimumLength(3)
            .WithMessage("Le nom doit comporter au moins 3 caractères");

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage("L'adresse e-mail est requise")
            .EmailAddress()
            .WithMessage("L'adresse e-mail est invalide");

        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage("Le mot de passe est requis")
            .Must(BeStrongPassword)
            .WithMessage("Le mot de passe est faible !");
    }

    private bool BeStrongPassword(string password) =>
        (new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")).IsMatch(
            password
        );
}
