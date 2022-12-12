using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models
{
    public class Location
    {
        public Location() 
        {
            this.rooms = new HashSet<Room>();
        }
        [Key]
        public Guid id_location { get; set; }
        public string? city { get; set; }
        [JsonIgnore]
        public virtual ICollection<Room> rooms { get; set; }

    }
}
