using APBD12.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD12.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Country> Country { get; set; }
    public DbSet<Trip> Trip { get; set; }
    public DbSet<Client> Client { get; set; }

    public DbSet<ClientTrip> ClientTrip { get; set; }
    public DbSet<CountryTrip> CountryTrip { get; set; }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
}