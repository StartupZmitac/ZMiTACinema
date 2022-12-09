using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Models
{
    public class Room
    {
        [Key]
        public Guid id_room { get; set; }
        public int column { get; set; }
        public int row { get; set; }
        public string taken_seats { get; set; }
        public string unavailable_seats { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
        public virtual Location location { get; set; }
    }
}
