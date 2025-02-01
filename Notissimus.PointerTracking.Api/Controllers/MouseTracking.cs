using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MouseTracking.Api.Dtos;
namespace MouseTracking.Api.Controllers;

[ApiController]
[Route("api/mouse-tracking")]
public class MouseTracking(ILogger<MouseTracking> log) : ControllerBase
{
    [HttpPost(Name = "PostMouseTracking")]
    public IActionResult Post(MouseMovementDto dto)
    {
        if (dto.X.Length != dto.Y.Length || dto.X.Length != dto.T.Length)
        {
            return BadRequest();
        }


        log.LogInformation(dto.ToString());
        return Ok();
    }
}
