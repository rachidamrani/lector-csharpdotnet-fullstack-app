using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models.Books;

namespace LectorNet.Application.Books;

public interface IBooksRepository : IGenericRepository<Book>
{
    Task<bool> ExistsAsync(string isbn);
}