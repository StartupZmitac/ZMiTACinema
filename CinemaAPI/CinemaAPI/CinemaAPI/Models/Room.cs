using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models
{
    public class Room
    {
        public Room() 
        { 
            this.Screenings = new HashSet<Screening>();
        }

        [Key]
        public Guid id_room { get; set; }
        public int column { get; set; }
        public int row { get; set; }
        public string taken_seats { get; set; }
        public string unavailable_seats { get; set; }
        public int room_number { get; set; }
        public Guid? id_location { get; set; }
        [JsonIgnore]
        [ForeignKey("id_location")]
        public virtual Location? _location { get; set; }
        [JsonIgnore]
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
