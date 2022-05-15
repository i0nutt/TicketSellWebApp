using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSellWebApp.Migrations
{
    public partial class ShowMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremierDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Show");
        }
    }
}
