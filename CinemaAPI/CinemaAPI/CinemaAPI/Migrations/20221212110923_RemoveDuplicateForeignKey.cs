using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDuplicateForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations__locationid_location",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Films__filmId_Film",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Rooms__roomid_room",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rooms__roomid_room",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets__roomid_room",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Screenings__filmId_Film",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings__roomid_room",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Rooms__locationid_location",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "_roomid_room",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "_filmId_Film",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "_roomid_room",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "_locationid_location",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_id_room",
                table: "Tickets",
                column: "id_room");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_Id_Film",
                table: "Screenings",
                column: "Id_Film");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_id_room",
                table: "Screenings",
                column: "id_room");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_id_location",
                table: "Rooms",
                column: "id_location");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_id_location",
                table: "Rooms",
                column: "id_location",
                principalTable: "Locations",
                principalColumn: "id_location");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Films_Id_Film",
                table: "Screenings",
                column: "Id_Film",
                principalTable: "Films",
                principalColumn: "Id_Film");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Rooms_id_room",
                table: "Screenings",
                column: "id_room",
                principalTable: "Rooms",
                principalColumn: "id_room");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rooms_id_room",
                table: "Tickets",
                column: "id_room",
                principalTable: "Rooms",
                principalColumn: "id_room");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_id_location",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Films_Id_Film",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Rooms_id_room",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rooms_id_room",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_id_room",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_Id_Film",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_id_room",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_id_location",
                table: "Rooms");

            migrationBuilder.AddColumn<Guid>(
                name: "_roomid_room",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "_filmId_Film",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "_roomid_room",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "_locationid_location",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets__roomid_room",
                table: "Tickets",
                column: "_roomid_room");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings__filmId_Film",
                table: "Screenings",
                column: "_filmId_Film");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings__roomid_room",
                table: "Screenings",
                column: "_roomid_room");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms__locationid_location",
                table: "Rooms",
                column: "_locationid_location");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations__locationid_location",
                table: "Rooms",
                column: "_locationid_location",
                principalTable: "Locations",
                principalColumn: "id_location");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Films__filmId_Film",
                table: "Screenings",
                column: "_filmId_Film",
                principalTable: "Films",
                principalColumn: "Id_Film");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Rooms__roomid_room",
                table: "Screenings",
                column: "_roomid_room",
                principalTable: "Rooms",
                principalColumn: "id_room");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rooms__roomid_room",
                table: "Tickets",
                column: "_roomid_room",
                principalTable: "Rooms",
                principalColumn: "id_room");
        }
    }
}
