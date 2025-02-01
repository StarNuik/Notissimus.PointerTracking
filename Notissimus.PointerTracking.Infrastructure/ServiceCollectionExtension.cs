using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notissimus.PointerTracking.Domain.Interfaces;
using Notissimus.PointerTracking.Infrastructure.Database;

namespace Notissimus.PointerTracking.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        services.AddDbContext<IPointerTrackingDb, PointerTrackingDb>(
            DbOptions.Set, ServiceLifetime.Singleton, ServiceLifetime.Scoped
            );
        
        return services;
    }
}