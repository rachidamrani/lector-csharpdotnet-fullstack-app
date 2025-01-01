using LectorNet.Application.Books;
using LectorNet.Domain.Models.Books;
using LectorNet.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LectorNet.Infrastructure.Books;

public class BooksRepository(LectorNetDbContext dbContext) : IBooksRepository
{
    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await dbContext.Books.ToListAsync();
    }

    public async Task AddAsync(Book book)
    {
        await dbContext.Books.AddAsync(book);
    }

    public Task UpdateAsync(Book book)
    {
        dbContext.Update(book);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Book book)
    {
        dbContext.Books.Remove(book);
        return Task.CompletedTask;
    }

    public async Task<bool> ExistsAsync(string isbn)
    {
        return await dbContext.Books.AnyAsync(book => book.Isbn == isbn);
    }
}