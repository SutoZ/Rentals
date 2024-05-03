using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rental.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.Scan(s =>
        s.FromCallingAssembly().AddClasses(c =>
        c.Where(c => c.IsClass && c.Name.EndsWith("Repository")))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        return services;
    }

    public static IServiceCollection AddDbConnection<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : DbContext
    {
        services.AddDbContext<RentalContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("RentalConnection"), contextOptionsBuilder =>
                contextOptionsBuilder.MigrationsAssembly(typeof(TDbContext).Assembly.FullName)));

        return services;
    }
}