using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD12.Models;

[PrimaryKey(nameof(IdClient),nameof(IdTrip))]
[Table("Client_Trip")]
public class ClientTrip
{
    [ForeignKey(nameof(Client))]
    public int IdClient { get; set; }
    [ForeignKey(nameof(Trip))]
    public int IdTrip { get; set; }
    public int RegisteredAt { get; set; }
    public int? PaymentDate { get; set; }

    public Client Client { get; set; }
    public Trip Trip { get; set; }
}