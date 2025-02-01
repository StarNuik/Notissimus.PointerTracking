using Notissimus.PointerTracking.Domain;
using Notissimus.PointerTracking.Infrastructure;

namespace MouseTracking.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var services = builder.Services;
        services.AddControllers();
        services.AddDomain();
        services.AddInfrastructure();

        var app = builder.Build();
        app.MapControllers();
        app.UseInfrastructure();
        
        app.Run();
    }
}