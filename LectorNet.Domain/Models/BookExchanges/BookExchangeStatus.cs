using Ardalis.SmartEnum;

namespace LectorNet.Domain.Models.BookExchanges;

public class BookExchangeStatus(string name, int value) : SmartEnum<BookExchangeStatus>(name, value)
{
    public static readonly BookExchangeStatus Pending = new(nameof(Pending),0);
    public static readonly BookExchangeStatus Accepted = new(nameof(Accepted),1);
    public static readonly BookExchangeStatus Completed = new(nameof(Completed),2);
    public static readonly BookExchangeStatus Cancelled = new(nameof(Cancelled),3);
}

