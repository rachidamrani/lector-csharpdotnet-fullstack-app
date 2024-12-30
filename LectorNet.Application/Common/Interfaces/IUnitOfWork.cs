namespace LectorNet.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}
