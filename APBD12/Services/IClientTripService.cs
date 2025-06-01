using APBD12.DTO_s;

namespace APBD12.Services;

public interface IClientTripService
{
    Task PostClientOnTrip(PostClientDto postClientDto, int clientId, int idTrip);
}