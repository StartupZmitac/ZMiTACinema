using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.Models
{
    public class Admin
    {
        [Key]
        public Guid Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
