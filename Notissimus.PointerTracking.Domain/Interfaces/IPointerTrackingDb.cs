using Microsoft.EntityFrameworkCore;
using Notissimus.PointerTracking.Domain.Entities;

namespace Notissimus.PointerTracking.Domain.Interfaces;

public interface IPointerTrackingDb
{
    public DbSet<PointerMovement> PointerMovements { get; }
}