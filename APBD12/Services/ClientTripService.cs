using APBD12.Data;
using APBD12.DTO_s;
using APBD12.Models;

namespace APBD12.Services;

public class ClientTripService : IClientTripService
{
    private readonly DatabaseContext _context;
    public ClientTripService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task PostClientOnTrip(PostClientDto postClientDto, int clientId, int idTrip)
    {
        await _context.ClientTrip.AddAsync(new ClientTrip()
        {
            IdClient = clientId,
            IdTrip = idTrip,
            PaymentDate = postClientDto.PaymentDate,
            RegisteredAt = DateTime.Now
        });
        await _context.SaveChangesAsync();
    }
}