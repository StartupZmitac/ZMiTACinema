using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Price_ID",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Price_ID",
                table: "Tickets",
                column: "Price_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prices_Price_ID",
                table: "Tickets",
                column: "Price_ID",
                principalTable: "Prices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prices_Price_ID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Price_ID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price_ID",
                table: "Tickets");
        }
    }
}
