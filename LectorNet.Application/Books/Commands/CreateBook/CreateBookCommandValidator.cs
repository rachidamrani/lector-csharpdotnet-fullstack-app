using FluentValidation;
using LectorNet.Domain.Models.Books;

namespace LectorNet.Application.Books.Commands.CreateBook;

public static class BookCommandValidators
{
    public static bool IsValidIsbn10(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 10)
            return false;

        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            if (!char.IsDigit(isbn[i]))
                return false;

            sum += (isbn[i] - '0') * (i + 1);
        }

        char checksum = isbn[9];
        int checksumValue = (checksum == 'X' || checksum == 'x') ? 10 : (checksum - '0');

        if (!char.IsDigit(checksum) && checksum != 'X' && checksum != 'x')
            return false;

        return sum % 11 == checksumValue;
    }


    public static bool IsValidIsbn13(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn) || isbn.Length != 13 || !isbn.All(char.IsDigit))
            return false;

        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            int digit = isbn[i] - '0';
            sum += digit * (i % 2 == 0 ? 1 : 3);
        }

        int checksum = (10 - (sum % 10)) % 10;

        return (isbn[12] - '0') == checksum;
    }
}


public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
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



