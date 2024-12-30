using Ardalis.SmartEnum;

namespace LectorNet.Domain.Models.Books;
public class BookGenre(string name, int value) : SmartEnum<BookGenre>(name, value)
{
    public static readonly BookGenre Fiction = new BookGenre("Fiction", 1);
    public static readonly BookGenre Mystery = new BookGenre("Mystère", 2);
    public static readonly BookGenre Thriller = new BookGenre("Thriller", 3);
    public static readonly BookGenre Romance = new BookGenre("Romance", 4);
    public static readonly BookGenre ScienceFiction = new BookGenre("Science-fiction", 5);
    public static readonly BookGenre Fantasy = new BookGenre("Fantaisie", 6);
    public static readonly BookGenre Biography = new BookGenre("Biographie", 7);
    public static readonly BookGenre History = new BookGenre("Histoire", 8);
    public static readonly BookGenre SelfHelp = new BookGenre("Développement personnel", 9);
    public static readonly BookGenre Philosophy = new BookGenre("Philosophie", 10);
    public static readonly BookGenre Poetry = new BookGenre("Poésie", 11);
    public static readonly BookGenre Business = new BookGenre("Affaires", 12);
    public static readonly BookGenre Health = new BookGenre("Santé", 13);
    public static readonly BookGenre Travel = new BookGenre("Voyage", 14);
    public static readonly BookGenre Children = new BookGenre("Enfants", 15);
    public static readonly BookGenre YoungAdult = new BookGenre("Jeunes adultes", 16);
    public static readonly BookGenre Religion = new BookGenre("Religion", 17);
    public static readonly BookGenre Art = new BookGenre("Art", 18);
    public static readonly BookGenre Science = new BookGenre("Science", 19);
    public static readonly BookGenre ComputerScience = new BookGenre("Informatique", 20);
    public static readonly BookGenre Politics = new BookGenre("Politique", 21);
    public static readonly BookGenre Dystopian = new BookGenre("Dystopian", 22);
    public static readonly BookGenre Classic = new BookGenre("Classic", 23);
    public static readonly BookGenre None = new BookGenre("None", 23);
}