using APBD12.DTO_s;

namespace APBD12.Services;

public interface ITripsService
{
    Task<PaginatedTripsDto> GetTrips(int page,int pageSize);
    Task<bool> TripExists(int idTrip);
    Task<bool> TripStarted(int idTrip);
}