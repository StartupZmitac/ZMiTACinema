using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class TicketSimplification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rooms_id_room",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Film",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "id_room",
                table: "Tickets",
                newName: "Screening_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_id_room",
                table: "Tickets",
                newName: "IX_Tickets_Screening_ID");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Screenings_Screening_ID",
                table: "Tickets",
                column: "Screening_ID",
                principalTable: "Screenings",
                principalColumn: "Screening_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Screenings_Screening_ID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.RenameColumn(
                name: "Screening_ID",
                table: "Tickets",
                newName: "id_room");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Screening_ID",
                table: "Tickets",
                newName: "IX_Tickets_id_room");

            migrationBuilder.AddColumn<string>(
                name: "Film",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Room",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rooms_id_room",
                table: "Tickets",
                column: "id_room",
                principalTable: "Rooms",
                principalColumn: "id_room");
        }
    }
}
