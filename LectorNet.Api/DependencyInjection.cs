using LectorNet.Api.MappingsProfiles;

namespace LectorNet.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddProblemDetails();
        services.AddHttpContextAccessor(); 
        services.AddMappings();
        
        return services;
    }
}