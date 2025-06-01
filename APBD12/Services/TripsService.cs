using APBD12.Data;
using Microsoft.EntityFrameworkCore;
using APBD12.DTO_s;

namespace APBD12.Services;

public class TripsService : ITripsService
{
    private readonly DatabaseContext _context;
    public TripsService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<PaginatedTripsDto> GetTrips(int page, int pageSize)
    {
        var trips = await _context.Trip
            .OrderByDescending(t => t.DateFrom)
            .Select(t =>
            new TripDto()
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.CountryTrip.Select(ct =>
                    new CountryDto()
                    {
                        Name = ct.Country.Name
                    }).ToList(),
                Clients = t.ClientTrip.Select(clt =>
                    new ClientDto()
                    {
                        FirstName = clt.Client.FirstName,
                        LastName = clt.Client.LastName
                    }).ToList()
            }).ToListAsync();

        var pagedTrips = trips
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        var paginatedTrips = new PaginatedTripsDto()
        {
            PageNum = page,
            PageSize = pageSize,
            Trips = pagedTrips
        };
        return paginatedTrips;
    }

    public Task<bool> TripExists(int idTrip)
    {
        return _context.Trip.AnyAsync(t => t.IdTrip == idTrip);
    }

    public async Task<bool> TripStarted(int idTrip)
    {
        var trip = await _context.Trip.FirstOrDefaultAsync(t => t.IdTrip == idTrip);
        if (trip.DateFrom < DateTime.Now)
        {
            return false;
        }

        return true;
    }
}