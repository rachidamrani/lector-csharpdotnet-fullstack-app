using System.ComponentModel.DataAnnotations;

namespace LectorNet.UI.ViewModels;

public class LoginModel
{
    [Required] [EmailAddress] public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}