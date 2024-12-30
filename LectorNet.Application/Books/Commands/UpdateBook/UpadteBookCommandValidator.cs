using FluentValidation;
using LectorNet.Application.Books.Commands.CreateBook;
using LectorNet.Domain.Models.Books;

namespace LectorNet.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty()
            .WithMessage("Le titre est requis")
            .MaximumLength(500);
        
        RuleFor(b => b.Author)
            .NotEmpty()
            .WithMessage("Le nom de le l'auteur est requis")
            .MaximumLength(100);

        RuleFor(b => b.Isbn)
            .NotEmpty()
            .WithMessage("L'ISBN est requis")
            .Must(isbn => BookCommandValidators.IsValidIsbn10(isbn) || BookCommandValidators.IsValidIsbn13(isbn))
            .WithMessage("L'ISBN est invalide");

        RuleFor(b => b.Genre)
            .Must(genre => BookGenre.TryFromName(genre, out _))
            .WithMessage("Le genre du livre est invalide");

        RuleFor(b => b.NumberOfPages)
            .Must(n => n > 0)
            .WithMessage("Le nombre de page doit être supérieur strictement à zéro");


        RuleFor(b => b.PublishingHouse)
            .NotEmpty()
            .WithMessage("La maison d'édition est requise");


        RuleFor(b => b.PublicationYear)
            .NotEmpty()
            .WithMessage("L'année de publication est requise");

        RuleFor(b => b.BookCoverLink)
            .NotEmpty()
            .WithMessage("L'image de la couverture est requise");
    }
}
