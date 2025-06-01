using APBD12.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD12.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;
    
    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var trips = await _tripsService.GetTrips(page,pageSize);
        return Ok(trips);
    }
}