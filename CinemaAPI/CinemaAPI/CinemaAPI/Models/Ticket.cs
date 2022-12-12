using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models;

public class Ticket
{
    [Key]
    public Guid Id { get; set; }
    public bool IsChecked { get; set; }
    public string? Film { get; set; }
    public bool IsPaid { get; set; }
    public int Room { get; set; }
    public string? Seat { get; set; }
    public DateTime Time { get; set; }
    public string Type { get; set; }
    public Guid? id_room { get; set; }
    [JsonIgnore]
    [ForeignKey("id_room")]
    public virtual Room? _room { get; set; }
}