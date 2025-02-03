using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notissimus.PointerTracking.Domain.Interfaces;
using Notissimus.PointerTracking.Infrastructure.Database;

namespace Notissimus.PointerTracking.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDatabases(config);

        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<IPointerTrackingDb, PointerTrackingDb>(
            opt => DbOptions.SetPostgres(opt, config),
            ServiceLifetime.Singleton);

        return services;
    }
}