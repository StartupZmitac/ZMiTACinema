using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_locationid_location",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Films_filmId_Film",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_Rooms_roomid_room",
                table: "Screenings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rooms_roomid_room",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_roomid_room",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_filmId_Film",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_roomid_room",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_locationid_location",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "roomid_room",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "filmId_Film",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "roomid_room",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "locationid_location",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "Seat",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Film",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "_roomid_room",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Screenings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Film",
                table: "Screenings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Seat",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Film",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "roomid_room",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Screenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Film",
                table: "Screenings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "filmId_Film",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "roomid_room",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "locationid_location",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_roomid_room",
                table: "Tickets",
                column: "roomid_room");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_filmId_Film",
                table: "Screenings",
                column: "filmId_Film");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_roomid_room",
                table: "Screenings",
                column: "roomid_room");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_locationid_location",
                table: "Rooms",
                column: "locationid_location");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_locationid_location",
                table: "Rooms",
                column: "locationid_location",
                principalTable: "Locations",
                principalColumn: "id_location",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Films_filmId_Film",
                table: "Screenings",
                column: "filmId_Film",
                principalTable: "Films",
                principalColumn: "Id_Film",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_Rooms_roomid_room",
                table: "Screenings",
                column: "roomid_room",
                principalTable: "Rooms",
                principalColumn: "id_room",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rooms_roomid_room",
                table: "Tickets",
                column: "roomid_room",
                principalTable: "Rooms",
                principalColumn: "id_room",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
