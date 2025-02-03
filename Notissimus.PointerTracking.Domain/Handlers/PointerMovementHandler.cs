using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Notissimus.PointerTracking.Domain.Dtos;
using Notissimus.PointerTracking.Domain.Entities;
using Notissimus.PointerTracking.Domain.Interfaces;

namespace Notissimus.PointerTracking.Domain.Handlers;

public class PointerMovementHandler(
    IPointerTrackingDb db,
    ILogger<PointerMovementHandler> log)
{
    public async Task<long> Insert(PointerMovementDto dto)
    {
        if (dto.X.Length != dto.Y.Length || dto.X.Length != dto.T.Length)
            throw new ArgumentException("X, Y and T arrays are not of the same length");

        var entity = Entity(dto);
        var entry = await db.PointerMovements.AddAsync(entity);
        await db.Commit();

        var entryId = entry.Entity.Id;
        log.LogInformation($"successful insert, id: {entryId}, length: {dto.T.Length}");

        return entryId;
    }

    public async Task<PointerMovement[]> SelectAll()
    {
        var result = await db.PointerMovements.ToArrayAsync();
        return result;
    }

    private static PointerMovement Entity(PointerMovementDto dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var entity = new PointerMovement
        {
            Json = json
        };

        return entity;
    }
}