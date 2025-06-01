using APBD12.Data;
using APBD12.DTO_s;
using APBD12.Models;
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

    public Task<bool> ClientExists(string pesel)
    {
        return _context.Client.AnyAsync(c => c.Pesel == pesel);
    }

    public async Task<int> PostClient(PostClientDto postClientDto)
    {
        var client = new Client()
        {
            Telephone = postClientDto.Telephone,
            FirstName = postClientDto.FirstName,
            LastName = postClientDto.LastName,
            Email = postClientDto.Email,
            Pesel = postClientDto.Pesel
        };

        await _context.Client.AddAsync(client);
        await _context.SaveChangesAsync();

        return client.IdClient;
    }
}