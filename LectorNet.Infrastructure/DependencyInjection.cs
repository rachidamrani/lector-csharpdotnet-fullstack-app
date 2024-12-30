using System.Text;
using LectorNet.Application.Books;
using LectorNet.Application.Common.Interfaces;
using LectorNet.Application.Users;
using LectorNet.Infrastructure.Authentication.PasswordHasher;
using LectorNet.Infrastructure.Books.Persistence;
using LectorNet.Infrastructure.Common.Persistence;
using LectorNet.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LectorNet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, IConfiguration configuration)
    {
        return services.AddPersistence(connectionString);
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<LectorNetDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);

        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IUsersRepository,UsersRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<LectorNetDbContext>());
        
        return services;
    }
}