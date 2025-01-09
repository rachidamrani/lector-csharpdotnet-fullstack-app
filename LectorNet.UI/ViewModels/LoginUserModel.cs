using System.ComponentModel.DataAnnotations;

namespace LectorNet.UI.ViewModels;

public class LoginUserModel
{
    [Required(ErrorMessage = "L'adresse e-mail est requise")] 
    [EmailAddress(ErrorMessage = "L'adresse e-mail est invalide")] 
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Le mot de passe est requis")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}