using APBD12.Data;
using Microsoft.EntityFrameworkCore;

namespace APBD12.Services;

public class ClientsService : IClientsService
{
    private readonly DatabaseContext _context;
    public ClientsService(DatabaseContext context)
    {
        _context = context;
    }
    
    public Task<bool> ClientExists(int id)
    {
        return _context.Client.AnyAsync(c => c.IdClient == id);
    }

    public Task<bool> ClientAssignedToTrip(int id)
    {
        return _context.ClientTrip.AnyAsync(ct => ct.IdClient == id);
    }

    public async Task DeleteClient(int id)
    {
        _context.Client.Remove(await _context.Client.FirstOrDefaultAsync(c => c.IdClient == id));
    }
}