using CinemaAPI.Controllers;

namespace CinemaAPI.Models;

public class SeedData
{
    public static void Initialize(CinemaDbContext context)
    {
        if (context.Screenings.Any() || context.Rooms.Any() || context.Locations.Any())
        {
            return;
        }
        //TODO - add seed data

}
}