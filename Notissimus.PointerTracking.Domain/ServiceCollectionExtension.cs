using Microsoft.Extensions.DependencyInjection;
using Notissimus.PointerTracking.Domain.Handlers;

namespace Notissimus.PointerTracking.Domain;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<PointerMovementHandler>();
        
        return services;
    }
}