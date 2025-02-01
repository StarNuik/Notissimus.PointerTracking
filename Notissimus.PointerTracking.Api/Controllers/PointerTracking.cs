using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Notissimus.PointerTracking.Domain.Dtos;
using Notissimus.PointerTracking.Domain.Handlers;

namespace MouseTracking.Api.Controllers;

[ApiController]
[Route("api/pointer-tracking")]
public class PointerTracking(
    ILogger<PointerTracking> log,
    PointerMovementHandler handler) : ControllerBase
{
    [HttpPost(Name = "PostMouseTracking")]
    public IActionResult Post(PointerMovementDto dto)
    {
        log.LogInformation(dto.ToString());
        
        try
        {
            handler.Save(dto);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        
        return Ok();
    }
}
