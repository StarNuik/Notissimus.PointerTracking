using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Notissimus.PointerTracking.Domain.Dtos;
using Notissimus.PointerTracking.Domain.Entities;
using Notissimus.PointerTracking.Domain.Handlers;
using Notissimus.PointerTracking.Domain.Interfaces;
using Notissimus.PointerTracking.Infrastructure.Database;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tests.Unit;

public class TestPointerMovementHandler_Insert
{
    /// <summary>
    /// Запись правильного дто
    /// </summary>
    /// <returns>
    /// - В дб 1 запись
    /// - id из сервиса и id в дб равны
    /// - json в дб равен дто на входе
    /// </returns>
    [Fact]
    public async Task WellFormedDto_Ok()
    {
        // Arrange
        var mockLogger = Mock.Of<ILogger<PointerMovementHandler>>();

        await using var db = TestDatabase();
        
        var service = new PointerMovementHandler(db, mockLogger);
        
        var dto = new PointerMovementDto
        {
            X = [1, 2],
            Y = [3, 4],
            T = [5, 6],
        };
        
        // Act
        var result = await service.Insert(dto);
        
        // Assert
        db.PointerMovements.Count()
            .Should().Be(1);

        var entry = db.PointerMovements.Single();
        entry.Id
            .Should().Be(result);

        var haveDto = JsonSerializer.Deserialize<PointerMovementDto>(entry.Json);
        haveDto.Should().BeEquivalentTo(dto, opt => opt.WithStrictOrdering());
    }
    
    /// <summary>
    /// Запись дто с массивами разных размеров
    /// </summary>
    /// <returns>
    /// - ArgumentException
    /// </returns>
    [Fact]
    public async Task MalformedDto_ArgumentException()
    {
        // Arrange
        var mockLogger = Mock.Of<ILogger<PointerMovementHandler>>();

        await using var db = TestDatabase();
        
        var service = new PointerMovementHandler(db, mockLogger);
        
        var dto = new PointerMovementDto
        {
            X = [1],
            Y = [2, 3],
            T = [4, 5, 6],
        };
        
        // Act
        var call = async () => await service.Insert(dto);
        
        // Assert
        call.Should().ThrowExactlyAsync<ArgumentException>();
    }

    private PointerTrackingDb TestDatabase()
    {
        var opt = new DbContextOptionsBuilder<PointerTrackingDb>()
            .UseInMemoryDatabase("test")
            .Options;
        
        return new PointerTrackingDb(opt); 
    }
}