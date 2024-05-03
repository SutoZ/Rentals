using Microsoft.Extensions.DependencyInjection;
using Rental.Core.Mappings;
using System.Reflection;

namespace Rental.Core.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(CustomMappingProfile).Assembly);

        services.Scan(s =>
        s.FromCallingAssembly().AddClasses(c =>
        c.Where(c => c.IsClass && c.Name.EndsWith("Service")))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        return services;
    }
}
