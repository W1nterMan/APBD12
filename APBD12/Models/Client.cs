using System.ComponentModel.DataAnnotations;

namespace APBD12.Models;

public class Client
{
    [Key]
    public int IdClient { get; set; }
    [MaxLength(120)]
    public string FirstName { get; set; }
    [MaxLength(120)]
    public string LastName { get; set; }
    [MaxLength(120)]
    public string Email { get; set; }
    [MaxLength(120)]
    public string Telephone { get; set; }
    [MaxLength(120)]
    public string Pesel { get; set; }
    
    public ICollection<ClientTrip> ClientTrip { get; set; }
}