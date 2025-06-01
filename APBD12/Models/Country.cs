using System.ComponentModel.DataAnnotations;

namespace APBD12.Models;

public class Country
{
    [Key]
    public int IdCountry { get; set; }
    [MaxLength(120)]
    public string Name { get; set; }

    public ICollection<CountryTrip> CountryTrip { get; set; }
}