using System.ComponentModel.DataAnnotations;

namespace LectorNet.UI.ViewModels;

public class AddBookModel
{
    [Required(ErrorMessage = "Le titre du livre est requis")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le nom du l'auteur est requis")]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessage = "L'ISBN du livre est requis")]
    public string Isbn { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le genre du livre est requis")]
    public string Genre { get; set; } = string.Empty;

    [Required(ErrorMessage = "L’année de publication du livre est requise")]
    public string PublicationYear { get; set; } = string.Empty;

    [Required(ErrorMessage = "La maison d'édition du livre est requise")]
    public string PublishingHouse { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le nombre de pages du livre est requis")]
    [Range(1, int.MaxValue, ErrorMessage = "Le nombre de pages doit être un entier supérieur strictement à zéro")]
    public int NumberOfPages { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string BookCoverLink { get; set; } = string.Empty;

    public bool AlreadyRead { get; set; }
}
