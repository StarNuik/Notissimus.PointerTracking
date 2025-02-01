using Microsoft.EntityFrameworkCore;
using Notissimus.PointerTracking.Domain.Entities;
using Notissimus.PointerTracking.Domain.Interfaces;

namespace Notissimus.PointerTracking.Infrastructure.Database;

public class PointerTrackingDb : DbContext, IPointerTrackingDb
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // builder.uses
        base.OnConfiguring(builder);
    }

    public DbSet<PointerMovement> PointerMovements { get; set; }
}