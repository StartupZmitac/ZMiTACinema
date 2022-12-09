namespace CinemaAPI.Data;

public class Ticket
{
    public Guid Id { get; set; }
    public bool IsChecked { get; set; }
    public string Film { get; set; }
    public bool IsPaid { get; set; }
    public int Room { get; set; }
    public int Seat { get; set; }
    public DateTime Time { get; set; }
}