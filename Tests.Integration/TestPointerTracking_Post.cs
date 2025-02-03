using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MouseTracking.Api;
using Notissimus.PointerTracking.Domain.Dtos;

namespace Tests.Integration;

public class TestPointerTracking_Post(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task WellFormedDto_ReturnsId()
    {
        // Arrange
        var client = factory.CreateClient();
        
        var dto = new PointerMovementDto{
            X = [1, 2],
            Y = [3, 4],
            T = [5, 6]
        };
        
        // Act
        var response = await client.PostAsJsonAsync("api/pointer-tracking", dto);

        // Assert
        response.StatusCode
            .Should().Be(HttpStatusCode.OK);
    }
}