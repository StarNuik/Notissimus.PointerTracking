using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Notissimus.PointerTracking.Domain.Dtos;
using Notissimus.PointerTracking.Domain.Handlers;

namespace MouseTracking.Api.Controllers;

[ApiController]
[Route("api/pointer-tracking")]
public class PointerTrackingController(
    PointerMovementHandler handler) : ControllerBase
{
    [HttpPost(Name = "PostMouseTracking")]
    public async Task<IActionResult> Post(PointerMovementDto dto)
    {
        try
        {
            var response = await handler.Insert(dto);
            return OkJson(response);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await handler.SelectAll();
        
        return OkJson(response, writeIndented: true);
    }

    private IActionResult OkJson<T>(T response, bool writeIndented = false)
    {
        var opt = new JsonSerializerOptions(JsonSerializerOptions.Default)
        {
            WriteIndented = writeIndented
        };

        var json = JsonSerializer.Serialize(response, opt);
        return Ok(json);
    }
}