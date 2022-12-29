using CinemaAPI.Controllers;


namespace CinemaAPI.Models
{
    public class SeedData
    {
        public static void Initialize(CinemaDbContext context)
        {
            if (context.Rooms.Any() || context.Screenings.Any() || context.Locations.Any())
            {
                return;
            }

            var miechow = new Location()
            {
                id_location = Guid.NewGuid(),
                city = "Miechów"
            };

            context.Rooms.AddRange(

                new Room()
                {
                    id_location = miechow.id_location,
                    id_room = Guid.NewGuid(),
                    room_number = 1,
                    row = 6,
                    column = 6,
                    taken_seats = " ",
                    unavailable_seats = " "
                }

              );

            context.Locations.AddRange(

                miechow


                );

        }
    }
}
