using Microsoft.EntityFrameworkCore;
using Notissimus.PointerTracking.Domain.Entities;
using Notissimus.PointerTracking.Domain.Interfaces;

namespace Tests.Integration.Infrastructure;

public class TestPointerTrackingDb(DbContextOptions<Notissimus.PointerTracking.Infrastructure.Database.PointerTrackingDb> options) : DbContext(options)
{
    public DbSet<PointerMovement> PointerMovements { get; set; }

    public async Task Truncate()
    {
        await base.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [TableName]");
    }
}