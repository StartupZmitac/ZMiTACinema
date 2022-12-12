using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models
{
    public class Screening
    {
        [Key]
        public Guid Screening_ID { get; set; }
        public int Room { get; set; }
        public string? Film { get; set; }
        public DateTime Time { get; set; }
        public string? Location { get; set; }
        public Guid? id_room { get; set; }
        public Guid? Id_Film { get; set; }
        [JsonIgnore]
        [ForeignKey("id_room")]
        public virtual Room? _room { get; set; }
        [JsonIgnore]
        [ForeignKey("Id_Film")]
        public virtual Film? _film { get; set; }
    }
}
