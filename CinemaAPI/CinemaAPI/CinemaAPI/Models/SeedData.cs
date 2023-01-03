using CinemaAPI.Controllers;


namespace CinemaAPI.Models
{
    public class SeedData
    {
        public static void Initialize(CinemaDbContext context)
        {
            if (context.Rooms.Any() || context.Screenings.Any() || context.Locations.Any() || context.Films.Any())
            {
                return;
            }

            // Locations 
            var miechow = new Location()
            {
                id_location = Guid.NewGuid(),
                city = "Miechów"
            };

            var katowice = new Location()
            {
                id_location = Guid.NewGuid(),
                city = "Katowice"
            };

            var wadowice = new Location()
            {
                id_location = Guid.NewGuid(),
                city = "Wadowice"
            };

            var wilkowyje = new Location()
            {
                id_location = Guid.NewGuid(),
                city = "Wilkowyje"
            };

            var knyszyn = new Location()
            {
                id_location = Guid.NewGuid(),
                city = "Knyszyn"
            };

            //Films
           var nieznajomy = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 18,
                Category = " Romanse ",
                Dubbing = true,
                ImageSource = " ",
                Language = "en-USA ",
                Name = " Nieznajomy z wydzia³u ",
                Sub = true,
                Time = 1
            };

            var poprawka = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 16,
                Category = " Akcja ",
                Dubbing = true,
                ImageSource = " ",
                Language = " en-USA ",
                Name = " Poprawka ",
                Sub = true,
                Time = 1
            };

            var poprawka_2 = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 16,
                Category = " Akcja ",
                Dubbing = true,
                ImageSource = " ",
                Language = " en-USA ",
                Name = " Poprawka 2 ",
                Sub = true,
                Time = 1
            };

            var poprawka_3 = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 16,
                Category = " Akcja ",
                Dubbing = true,
                ImageSource = " ",
                Language = " en-USA ",
                Name = " Poprawka 3 ",
                Sub = true,
                Time = 1
            };

            var poprawka_4 = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 16,
                Category = " Akcja ",
                Dubbing = true,
                ImageSource = " ",
                Language = " en-USA ",
                Name = " Poprawka 4 ",
                Sub = true,
                Time = 1
            };

            //Rooms
            var miechowPokoj1 = new Room()
            {
                id_location = miechow.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var miechowPokoj2 = new Room()
            {
                id_location = miechow.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var katowicePokoj1 = new Room()
            {
                id_location = katowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var katowicePokoj2 = new Room()
            {
                id_location = katowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var knyszynPokoj1 = new Room()
            {
                id_location = knyszyn.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var knyszynPokoj2 = new Room()
            {
                id_location = knyszyn.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var wilkowyjePokoj1 = new Room()
            {
                id_location = wilkowyje.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var wilkowyjePokoj2 = new Room()
            {
                id_location = wilkowyje.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var wadowicePokoj1 = new Room()
            {
                id_location = wadowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            var wadowicePokoj2 = new Room()
            {
                id_location = wadowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 6,
                taken_seats = " ",
                unavailable_seats = " "
            };

            context.Locations.AddRange( miechow, katowice, knyszyn, wadowice, wilkowyje );

            context.Rooms.AddRange( miechowPokoj1, miechowPokoj2, katowicePokoj1, katowicePokoj2, 
                                    knyszynPokoj1, knyszynPokoj2, wilkowyjePokoj1, wilkowyjePokoj2, 
                                    wadowicePokoj1, wadowicePokoj2 );

            context.Films.AddRange( nieznajomy, poprawka, poprawka_2, poprawka_3, poprawka_4 ); 

            context.SaveChanges();

        }
    }
}
