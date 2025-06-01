namespace APBD12.Services;

public interface IClientsService
{
    Task<bool> ClientExists(int id);
    Task<bool> ClientAssignedToTrip(int id);
    Task DeleteClient(int id);
}