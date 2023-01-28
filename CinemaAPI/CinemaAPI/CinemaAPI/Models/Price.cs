using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models

{
    public class Price
    {
        public Price() 
        {
            this.Tickets = new HashSet<Ticket>();   
        }
        public Guid Id { get; set; }
        public string Type { get; set; }
        public float Cost { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
