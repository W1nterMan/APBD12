using System.ComponentModel.DataAnnotations;

namespace APBD12.Models;

public class Trip
{
    [Key]
    public int IdTrip { get; set; }
    [MaxLength(120)]
    public string Name { get; set; }
    [MaxLength(220)]
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }

    public ICollection<CountryTrip> CountryTrip { get; set; }
    public ICollection<ClientTrip> ClientTrip { get; set; }
    
}