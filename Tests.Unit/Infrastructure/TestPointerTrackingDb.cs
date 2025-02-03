using Microsoft.EntityFrameworkCore;
using Notissimus.PointerTracking.Domain.Entities;
using Notissimus.PointerTracking.Domain.Interfaces;

namespace Tests.Unit.Infrastructure;

public class TestPointerTrackingDb : IPointerTrackingDb
{
    public void Dispose() {}

    public DbSet<PointerMovement> PointerMovements { get; }
    public Task Commit()
    {
        throw new NotImplementedException();
    }
}