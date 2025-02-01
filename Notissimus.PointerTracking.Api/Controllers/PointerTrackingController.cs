using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Notissimus.PointerTracking.Domain.Dtos;
using Notissimus.PointerTracking.Domain.Handlers;

namespace MouseTracking.Api.Controllers;

[ApiController]
[Route("api/pointer-tracking")]
public class PointerTrackingController(
    ILogger<PointerTrackingController> log,
    PointerMovementHandler handler) : ControllerBase
{
    [HttpPost(Name = "PostMouseTracking")]
    public async Task<IActionResult> Post(PointerMovementDto dto)
    {
        try
        {
            var result = await handler.Insert(dto);
            return Ok(result);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var data = await handler.SelectAll();
        var json = JsonSerializer.Serialize(data);
        return Ok(json);
    }
}
