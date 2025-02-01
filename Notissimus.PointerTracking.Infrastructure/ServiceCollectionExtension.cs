using Microsoft.Extensions.DependencyInjection;

namespace Notissimus.PointerTracking.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services.AddSwaggerGen();
    }
}