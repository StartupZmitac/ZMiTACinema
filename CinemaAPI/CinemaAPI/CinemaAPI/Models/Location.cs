using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Models
{
    public class Location
    {
        [Key]
        public Guid id_location { get; set; }
        public string city { get; set; }
        public virtual ICollection<Room> rooms { get; set; }

    }
}
