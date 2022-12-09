using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    IdFilm = table.Column<Guid>(name: "Id_Film", type: "uniqueidentifier", nullable: false),
                    Is3D = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dubbing = table.Column<bool>(type: "bit", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub = table.Column<bool>(type: "bit", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.IdFilm);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    idlocation = table.Column<Guid>(name: "id_location", type: "uniqueidentifier", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.idlocation);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    idroom = table.Column<Guid>(name: "id_room", type: "uniqueidentifier", nullable: false),
                    column = table.Column<int>(type: "int", nullable: false),
                    row = table.Column<int>(type: "int", nullable: false),
                    takenseats = table.Column<string>(name: "taken_seats", type: "nvarchar(max)", nullable: false),
                    unavailableseats = table.Column<string>(name: "unavailable_seats", type: "nvarchar(max)", nullable: false),
                    locationidlocation = table.Column<Guid>(name: "locationid_location", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.idroom);
                    table.ForeignKey(
                        name: "FK_Rooms_Locations_locationid_location",
                        column: x => x.locationidlocation,
                        principalTable: "Locations",
                        principalColumn: "id_location",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    ScreeningID = table.Column<Guid>(name: "Screening_ID", type: "uniqueidentifier", nullable: false),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Film = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFilm = table.Column<int>(name: "Id_Film", type: "int", nullable: false),
                    IdRoom = table.Column<int>(name: "Id_Room", type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomidroom = table.Column<Guid>(name: "roomid_room", type: "uniqueidentifier", nullable: false),
                    filmIdFilm = table.Column<Guid>(name: "filmId_Film", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.ScreeningID);
                    table.ForeignKey(
                        name: "FK_Screenings_Films_filmId_Film",
                        column: x => x.filmIdFilm,
                        principalTable: "Films",
                        principalColumn: "Id_Film",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screenings_Rooms_roomid_room",
                        column: x => x.roomidroom,
                        principalTable: "Rooms",
                        principalColumn: "id_room",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    Film = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Seat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    roomidroom = table.Column<Guid>(name: "roomid_room", type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Rooms_roomid_room",
                        column: x => x.roomidroom,
                        principalTable: "Rooms",
                        principalColumn: "id_room",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_locationid_location",
                table: "Rooms",
                column: "locationid_location");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_filmId_Film",
                table: "Screenings",
                column: "filmId_Film");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_roomid_room",
                table: "Screenings",
                column: "roomid_room");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_roomid_room",
                table: "Tickets",
                column: "roomid_room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
