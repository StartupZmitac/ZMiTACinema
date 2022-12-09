namespace CinemaAPI.Models
{
    public class Location
    {
        public string city { get; set; }
        public Guid id_location { get; set; }
        public virtual ICollection<Room> rooms { get; set; }

    }
}
