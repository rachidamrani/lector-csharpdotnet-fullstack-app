using System.Reflection;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Domain.Models;
using LectorNet.Domain.Models.BookExchanges;
using LectorNet.Domain.Models.Books;
using LectorNet.Domain.Models.Challenges;
using LectorNet.Domain.Models.Common;
using LectorNet.Domain.Models.Invitations;
using LectorNet.Domain.Models.Summaries;
using LectorNet.Domain.Models.Users;
using LectorNet.Domain.Models.UsersBooksReactions;
using LectorNet.Domain.Models.UsersReviews;
using Microsoft.EntityFrameworkCore;

namespace LectorNet.Infrastructure.Common.Persistence;

public class LectorNetDbContext(DbContextOptions<LectorNetDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Summary> Summaries => Set<Summary>();
    public DbSet<Challenge> Challenges => Set<Challenge>();
    public DbSet<BookExchange> BookExchanges => Set<BookExchange>();
    public DbSet<UserBookReaction> UsersBooksReactions => Set<UserBookReaction>();
    public DbSet<UserReview> UsersReviews => Set<UserReview>();
    public DbSet<Invitation> Invitations => Set<Invitation>();
    public DbSet<Message> Messages => Set<Message>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=LectorNetDB;User Id=sa;Password=Pass123@@;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
