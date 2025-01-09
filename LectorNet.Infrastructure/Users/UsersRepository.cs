using LectorNet.Application.Users;
using LectorNet.Domain.Models.Users;
using LectorNet.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LectorNet.Infrastructure.Users;

public class UsersRepository(LectorNetDbContext dbContext) : IUsersRepository
{
    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllAsync(Guid? userId)
    {
        return await Task.FromResult(new List<User>());
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(User entity)
    {
        await dbContext.Users.AddAsync(entity);
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistByEmailAsync(string email)
    {
        return await dbContext.Users.AnyAsync(user => user.Email == email);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }
}
