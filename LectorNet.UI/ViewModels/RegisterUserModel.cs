using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LectorNet.UI.ViewModels;

public class RegisterUserModel
{
    [Required(ErrorMessage = "Le nom est requis")]
    [MinLength(3, ErrorMessage = "Le prénom doit comporter au moins 3 caractères")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Le prénom est requis")]
    [MinLength(3, ErrorMessage = "Le prénom doit comporter au moins 3 caractères")]
    public string? LastName { get; set; }
    
    [Required(ErrorMessage = "L'adresse e-mail est requise")]
    [EmailAddress(ErrorMessage = "L'adresse e-mail est invalide")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Le mot de passe est requis")]
    [DisplayName(displayName: "Mot de passe")]
    [PasswordValidation(ErrorMessage = "Le mot de passe est faible")]
    public string? Password { get; set; }
    
    [Required(ErrorMessage = "La confirmation du mot de passe est requise")]
    [DisplayName(displayName: "Confirmation du mot de passe")]
    [Compare("Password", ErrorMessage = "Les mots de passes doivent être identiques")]
    public string? ConfirmPassword { get; set; }
}


public class PasswordValidationAttribute : ValidationAttribute
{
    // Define a Regex for password validation
    private const string PasswordPattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

    // Override the IsValid method to perform the regex validation
    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        // Convert the value to string and check it against the regex
        string? password = value.ToString();
        Regex regex = new Regex(PasswordPattern);
        return regex.IsMatch(password!);
    }

    // Custom error message
    public override string FormatErrorMessage(string name)
    {
        return $"Le {name} doit contenir au moins 8 caractères, inclure une lettre majuscule, une lettre minuscule, un chiffre et un caractère spécial.";
    }
}