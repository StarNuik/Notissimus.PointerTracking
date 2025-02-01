using Microsoft.EntityFrameworkCore;
using Notissimus.PointerTracking.Domain.Entities;
using Notissimus.PointerTracking.Domain.Interfaces;

namespace Notissimus.PointerTracking.Infrastructure.Database;

public class PointerTrackingDb(DbContextOptions<PointerTrackingDb> options) : DbContext(options), IPointerTrackingDb
{
    public DbSet<PointerMovement> PointerMovements { get; set; }
    
    public async Task Commit()
    {
        await base.SaveChangesAsync();
    }
}