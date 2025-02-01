using Notissimus.PointerTracking.Infrastructure;

namespace MouseTracking.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var services = builder.Services;
        services.AddControllers();
        services.AddInfrastructureServices();

        var app = builder.Build();
        app.MapControllers();
        app.UseInfrastructure();

        app.Run();
    }
}