using APBD12.DTO_s;
using APBD12.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD12.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;
    private readonly IClientTripService _clientTripService;
    private readonly IClientsService _clientsService;
    
    public TripsController(ITripsService tripsService, IClientTripService clientTripService, IClientsService clientsService)
    {
        _tripsService = tripsService;
        _clientTripService = clientTripService;
        _clientsService = clientsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var trips = await _tripsService.GetTrips(page,pageSize);
        return Ok(trips);
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> PostClientTrip([FromBody] PostClientDto postClientDto,int idTrip)
    {
        if (await _clientsService.ClientExists(postClientDto.Pesel))
        {
            return Conflict("Client already exists");
        }
        if (!await _tripsService.TripExists(idTrip))
        {
            return NotFound($"No trip with this id: {idTrip}");
        }
        if (await _tripsService.TripStarted(idTrip))
        {
            return Conflict("Trip has already started");
        }
        
        var clientId = await _clientsService.PostClient(postClientDto);
        await _clientTripService.PostClientOnTrip(postClientDto, clientId, idTrip);
        return Created("",new {id = clientId});
    }
}