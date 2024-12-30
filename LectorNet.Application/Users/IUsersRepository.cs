using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models.Users;

namespace LectorNet.Application.Users;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<bool> ExistByEmailAsync(string email);
    Task<User?> GetByEmailAsync(string email);
}