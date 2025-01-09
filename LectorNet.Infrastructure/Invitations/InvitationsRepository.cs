using LectorNet.Application.Invitations;
using LectorNet.Domain.Models.Invitations;
using LectorNet.Infrastructure.Common.Persistence;

namespace LectorNet.Infrastructure.Invitations;

public class InvitationsRepository(LectorNetDbContext dbContext) : IInvitationsRepository
{
    public async Task<Invitation?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Invitation>> GetAllAsync(Guid? userId = null)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Invitation entity)
    {
       await dbContext.Invitations.AddAsync(entity);
    }

    public async Task UpdateAsync(Invitation entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Invitation entity)
    {
        throw new NotImplementedException();
    }
}