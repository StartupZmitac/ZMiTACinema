using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models;

public class Ticket
{
    [Key]
    public Guid Id { get; set; }
    public bool IsChecked { get; set; }
    public bool IsPaid { get; set; }
    public string? Seat { get; set; }
    public string Type { get; set; }
    public Guid? Screening_ID { get; set; }
    [JsonIgnore]
    [ForeignKey("Screening_ID")]
    public virtual Screening? _screening { get; set; }
}