using LectorNet.Application.Books;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Invitations;
using LectorNet.Application.Users;
using LectorNet.Infrastructure.Authentication.PasswordHasher;
using LectorNet.Infrastructure.Books;
using LectorNet.Infrastructure.Common.Persistence;
using LectorNet.Infrastructure.Invitations;
using LectorNet.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LectorNet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddPersistence();
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<LectorNetDbContext>();

        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IUsersRepository,UsersRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IInvitationsRepository, InvitationsRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<LectorNetDbContext>());
        
        return services;
    }
}