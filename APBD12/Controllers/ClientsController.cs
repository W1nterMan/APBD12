using APBD12.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD12.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;
    
    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _clientsService.ClientExists(id))
        {
            return NotFound("Client with this id doesn`t exist.");
        }
        if (await _clientsService.ClientAssignedToTrip(id))
        {
            return Conflict("Client is assigned to trip, cannot delete.");
        }

        _clientsService.DeleteClient(id);
        return NoContent();
    }
    
}