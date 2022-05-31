using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineId = table.Column<int>(nullable: false),
                    From = table.Column<string>(maxLength: 50, nullable: false),
                    To = table.Column<string>(maxLength: 50, nullable: false),
                    Departure = table.Column<DateTime>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    BusinessSeats = table.Column<int>(nullable: false),
                    NonBusinessSeats = table.Column<int>(nullable: false),
                    TicketPrice = table.Column<float>(nullable: false),
                    ScheduledDays = table.Column<string>(nullable: true),
                    Meal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
