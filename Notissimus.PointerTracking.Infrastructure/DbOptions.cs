using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Notissimus.PointerTracking.Infrastructure;

public static class DbOptions
{
    public static void SetPostgres(DbContextOptionsBuilder builder, IConfiguration config)
    {
        builder.UseNpgsql(
            config.GetConnectionString("PointerTrackingDb"),
            b => b.MigrationsAssembly("Notissimus.PointerTracking.Migrations"));
    }
}