using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Room",
                table: "Screenings",
                newName: "id_room");

            migrationBuilder.AddColumn<Guid>(
                name: "id_room",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "id_room",
                table: "Screenings"
                );

            migrationBuilder.AddColumn<Guid>(
                name: "id_room",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.DropColumn(
                name: "Id_Film",
                table: "Screenings"
                );

            migrationBuilder.AddColumn<Guid>(
                name: "Id_Film",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id_location",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_room",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "id_location",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "id_room",
                table: "Screenings",
                newName: "Id_Room");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Room",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Film",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
