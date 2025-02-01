using Microsoft.EntityFrameworkCore;

namespace Notissimus.PointerTracking.Infrastructure;

public static class DbOptions
{
    public static void Set(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Data Source=../db.sqlite", 
            b => b.MigrationsAssembly("Notissimus.PointerTracking.Migrations"));
    }
}