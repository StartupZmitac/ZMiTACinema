using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Models;

public class Ticket
{
    [Key]
    public Guid Id { get; set; }
    public bool IsChecked { get; set; }
    public string Film { get; set; }
    public bool IsPaid { get; set; }
    public int Room { get; set; }
    public string Seat { get; set; }
    public DateTime Time { get; set; }
    public virtual Room room { get; set; }
}