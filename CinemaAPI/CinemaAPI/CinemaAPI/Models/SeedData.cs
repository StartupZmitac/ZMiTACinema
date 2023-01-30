using CinemaAPI.Controllers;
using System.Globalization;

namespace CinemaAPI.Models
{
    public class SeedData
    {
        public static CultureInfo culture = CultureInfo.InvariantCulture;
        public static string format = "dd/MM/yyyy HH:mm:ss";
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
                city = "Miechow"
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
                Category = "Romanse",
                Dubbing = false,
                ImageSource = "",
                Language = "en-USA",
                Name = "Nieznajomy z wydzialu",
                Sub = true,
                Time = 120
            };

            var poprawka = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 16,
                Category = "Akcja",
                Dubbing = true,
                ImageSource = "",
                Language = "en-USA",
                Name = "Poprawka",
                Sub = false,
                Time = 120
            };

            var poprawka_2 = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = true,
                Age = 16,
                Category = "Akcja",
                Dubbing = true,
                ImageSource = "",
                Language = "en-USA",
                Name = "Poprawka 2",
                Sub = true,
                Time = 90
            };

            var poprawka_3 = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 16,
                Category = "Akcja",
                Dubbing = true,
                ImageSource = "",
                Language = "en-USA",
                Name = "Poprawka 3",
                Sub = true,
                Time = 100
            };

            var poprawka_4 = new Film()
            {
                Id_Film = Guid.NewGuid(),
                Is3D = false,
                Age = 16,
                Category = "Akcja",
                Dubbing = true,
                ImageSource = "",
                Language = "en-USA",
                Name = "Poprawka 4",
                Sub = true,
                Time = 90
            };

            //Rooms
            var miechowPokoj1 = new Room()
            {
                id_location = miechow.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            var miechowPokoj2 = new Room()
            {
                id_location = miechow.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            var katowicePokoj1 = new Room()
            {
                id_location = katowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 9,
                taken_seats = "5R5C,",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            var katowicePokoj2 = new Room()
            {
                id_location = katowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 7,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,6R4C,"
            };

            var knyszynPokoj1 = new Room()
            {
                id_location = knyszyn.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 4,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,"
            };

            var knyszynPokoj2 = new Room()
            {
                id_location = knyszyn.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            var wilkowyjePokoj1 = new Room()
            {
                id_location = wilkowyje.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            var wilkowyjePokoj2 = new Room()
            {
                id_location = wilkowyje.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            var wadowicePokoj1 = new Room()
            {
                id_location = wadowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 1,
                row = 6,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            var wadowicePokoj2 = new Room()
            {
                id_location = wadowice.id_location,
                id_room = Guid.NewGuid(),
                room_number = 2,
                row = 6,
                column = 9,
                taken_seats = "",
                unavailable_seats = "0R4C,1R4C,2R4C,3R4C,4R4C,5R4C,"
            };

            context.Locations.AddRange(miechow, katowice, knyszyn, wadowice, wilkowyje);

            context.Rooms.AddRange(miechowPokoj1, miechowPokoj2, katowicePokoj1, katowicePokoj2,
                                    knyszynPokoj1, knyszynPokoj2, wilkowyjePokoj1, wilkowyjePokoj2,
                                    wadowicePokoj1, wadowicePokoj2);

            context.Films.AddRange(nieznajomy, poprawka, poprawka_2, poprawka_3, poprawka_4);

            context.Screenings.AddRange(

                //Miechow
                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = miechowPokoj1.room_number,
                    Film = nieznajomy.Name,
                    Time = DateTime.ParseExact("08/01/2023 21:37:00", format, culture),
                    Location = miechow.city,
                    id_room = miechowPokoj1.id_room,
                    Id_Film = nieznajomy.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = miechowPokoj2.room_number,
                    Film = poprawka.Name,
                    Time = DateTime.ParseExact("09/01/2023 16:30:00", format, culture),
                    Location = miechow.city,
                    id_room = miechowPokoj2.id_room,
                    Id_Film = poprawka.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = miechowPokoj1.room_number,
                    Film = poprawka_2.Name,
                    Time = DateTime.ParseExact("09/01/2023 17:45:00", format, culture),
                    Location = miechow.city,
                    id_room = miechowPokoj1.id_room,
                    Id_Film = poprawka_2.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = miechowPokoj1.room_number,
                    Film = poprawka_3.Name,
                    Time = DateTime.ParseExact("11/01/2023 17:45:00", format, culture),
                    Location = miechow.city,
                    id_room = miechowPokoj1.id_room,
                    Id_Film = poprawka_3.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = miechowPokoj2.room_number,
                    Film = poprawka_4.Name,
                    Time = DateTime.ParseExact("13/01/2023 17:00:00", format, culture),
                    Location = miechow.city,
                    id_room = miechowPokoj2.id_room,
                    Id_Film = poprawka_4.Id_Film

                },

                //Katowice
                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = katowicePokoj2.room_number,
                    Film = nieznajomy.Name,
                    Time = DateTime.ParseExact("08/01/2023 15:00:00", format, culture),
                    Location = katowice.city,
                    id_room = katowicePokoj2.id_room,
                    Id_Film = nieznajomy.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = katowicePokoj2.room_number,
                    Film = poprawka.Name,
                    Time = DateTime.ParseExact("08/01/2023 17:45:00", format, culture),
                    Location = katowice.city,
                    id_room = katowicePokoj2.id_room,
                    Id_Film = poprawka.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = katowicePokoj1.room_number,
                    Film = poprawka_2.Name,
                    Time = DateTime.ParseExact("09/01/2023 15:00:00", format, culture),
                    Location = katowice.city,
                    id_room = katowicePokoj1.id_room,
                    Id_Film = poprawka_2.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = katowicePokoj1.room_number,
                    Film = poprawka_3.Name,
                    Time = DateTime.ParseExact("11/01/2023 17:45:00", format, culture),
                    Location = katowice.city,
                    id_room = katowicePokoj1.id_room,
                    Id_Film = poprawka_3.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = katowicePokoj1.room_number,
                    Film = poprawka_4.Name,
                    Time = DateTime.ParseExact("13/01/2023 19:00:00", format, culture),
                    Location = katowice.city,
                    id_room = katowicePokoj1.id_room,
                    Id_Film = poprawka_4.Id_Film

                },


                //Knyszyn
                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = knyszynPokoj1.room_number,
                    Film = nieznajomy.Name,
                    Time = DateTime.ParseExact("08/01/2023 20:15:00", format, culture),
                    Location = knyszyn.city,
                    id_room = knyszynPokoj1.id_room,
                    Id_Film = nieznajomy.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = knyszynPokoj2.room_number,
                    Film = poprawka.Name,
                    Time = DateTime.ParseExact("10/01/2023 15:45:00", format, culture),
                    Location = knyszyn.city,
                    id_room = knyszynPokoj2.id_room,
                    Id_Film = poprawka.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = knyszynPokoj1.room_number,
                    Film = poprawka_2.Name,
                    Time = DateTime.ParseExact("11/01/2023 16:00:00", format, culture),
                    Location = knyszyn.city,
                    id_room = knyszynPokoj1.id_room,
                    Id_Film = poprawka_2.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = knyszynPokoj2.room_number,
                    Film = poprawka_3.Name,
                    Time = DateTime.ParseExact("12/01/2023 17:00:00", format, culture),
                    Location = knyszyn.city,
                    id_room = knyszynPokoj2.id_room,
                    Id_Film = poprawka_3.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = knyszynPokoj1.room_number,
                    Film = poprawka_4.Name,
                    Time = DateTime.ParseExact("14/01/2023 18:00:00", format, culture),
                    Location = knyszyn.city,
                    id_room = knyszynPokoj1.id_room,
                    Id_Film = poprawka_4.Id_Film

                },

                //Wadowice
                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wadowicePokoj2.room_number,
                    Film = nieznajomy.Name,
                    Time = DateTime.ParseExact("09/01/2023 18:00:00", format, culture),
                    Location = wadowice.city,
                    id_room = wadowicePokoj2.id_room,
                    Id_Film = nieznajomy.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wadowicePokoj2.room_number,
                    Film = poprawka.Name,
                    Time = DateTime.ParseExact("10/01/2023 17:00:00", format, culture),
                    Location = wadowice.city,
                    id_room = wadowicePokoj2.id_room,
                    Id_Film = poprawka.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wadowicePokoj1.room_number,
                    Film = poprawka_2.Name,
                    Time = DateTime.ParseExact("11/01/2023 18:00:00", format, culture),
                    Location = wadowice.city,
                    id_room = wadowicePokoj1.id_room,
                    Id_Film = poprawka_2.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wadowicePokoj1.room_number,
                    Film = poprawka_3.Name,
                    Time = DateTime.ParseExact("12/01/2023 19:00:00", format, culture),
                    Location = wadowice.city,
                    id_room = wadowicePokoj1.id_room,
                    Id_Film = poprawka_3.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wadowicePokoj1.room_number,
                    Film = poprawka_4.Name,
                    Time = DateTime.ParseExact("13/01/2023 18:00:00", format, culture),
                    Location = wadowice.city,
                    id_room = wadowicePokoj1.id_room,
                    Id_Film = poprawka_4.Id_Film

                },

                //Wilkowyje
                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wilkowyjePokoj1.room_number,
                    Film = nieznajomy.Name,
                    Time = DateTime.ParseExact("10/01/2023 18:00:00", format, culture),
                    Location = wilkowyje.city,
                    id_room = wilkowyjePokoj1.id_room,
                    Id_Film = nieznajomy.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wilkowyjePokoj1.room_number,
                    Film = poprawka.Name,
                    Time = DateTime.ParseExact("11/01/2023 15:30:00", format, culture),
                    Location = wilkowyje.city,
                    id_room = wilkowyjePokoj1.id_room,
                    Id_Film = poprawka.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wilkowyjePokoj1.room_number,
                    Film = poprawka_2.Name,
                    Time = DateTime.ParseExact("11/01/2023 19:00:00", format, culture),
                    Location = wilkowyje.city,
                    id_room = wilkowyjePokoj1.id_room,
                    Id_Film = poprawka_2.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wilkowyjePokoj2.room_number,
                    Film = poprawka_3.Name,
                    Time = DateTime.ParseExact("12/01/2023 15:15:00", format, culture),
                    Location = wilkowyje.city,
                    id_room = wilkowyjePokoj2.id_room,
                    Id_Film = poprawka_3.Id_Film

                },

                new Screening()
                {
                    Screening_ID = Guid.NewGuid(),
                    Room = wilkowyjePokoj2.room_number,
                    Film = poprawka_4.Name,
                    Time = DateTime.ParseExact("13/01/2023 16:00:00", format, culture),
                    Location = wilkowyje.city,
                    id_room = wilkowyjePokoj2.id_room,
                    Id_Film = poprawka_4.Id_Film

                });

            context.SaveChanges();

        }
    }
}
