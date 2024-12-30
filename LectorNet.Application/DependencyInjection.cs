using FluentValidation;
using LectorNet.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace LectorNet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            // options.AddBehavior<IPipelineBehavior<CreateBookCommand, ErrorOr<Book>>, CreateBookCommandBehavior>();
            options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection)); // register all fluent validation validators from the application assembly 
        
        return services;
    }
}