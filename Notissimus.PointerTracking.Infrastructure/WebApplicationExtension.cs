using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Notissimus.PointerTracking.Infrastructure;

public static class WebApplicationExtension
{
    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}