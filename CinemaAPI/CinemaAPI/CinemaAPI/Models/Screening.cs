namespace CinemaAPI.Models
{
    public class Screening
    {
        public Guid Screening_ID { get; set; }
        public int Room { get; set; }
        public string Film { get; set; }
        public DateTime Time { get; set; }
        public int Id_Film { get; set; }
        public int Id_Room { get; set; }
        public string Location { get; set; }
        public virtual Room room { get; set; }
        public virtual Film film { get; set; }
    }
}
