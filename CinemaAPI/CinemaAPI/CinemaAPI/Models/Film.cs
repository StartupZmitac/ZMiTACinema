using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models
{
    public class Film
    {
        public Film()
        {
            this.Screenings = new HashSet<Screening>();
        }
        [Key]
        public Guid Id_Film { get; set; }
        public bool Is3D { get; set; }
        public int Age { get; set; }
        public string Category { get; set; }
        public bool Dubbing { get; set; }

        public string ImageSource { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public bool Sub { get; set; }
        public int Time { get; set; }
        [JsonIgnore]
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
