using Notissimus.PointerTracking.Domain.Dtos;
using Notissimus.PointerTracking.Domain.Entities;
using Notissimus.PointerTracking.Domain.Interfaces;

namespace Notissimus.PointerTracking.Domain.Handlers;

public class PointerMovementHandler(IPointerTrackingDb db)
{
    public async Task Save(PointerMovementDto dto)
    {
        if (dto.X.Length != dto.Y.Length || dto.X.Length != dto.T.Length)
        {
            throw new ArgumentException("X, Y and T arrays are not of the same length");
        }

        var entity = Entity(dto);
        await db.PointerMovements.AddAsync(entity);
    }
    
    private static PointerMovement Entity(PointerMovementDto dto)
    {
        var entity = new PointerMovement
        {
            X = dto.X,
            Y = dto.Y,
            T = dto.T
        };
        
        return entity;
    }
}