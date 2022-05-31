using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingManagement.Migrations
{
    public partial class PassengersCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId",
                unique: true);
        }
    }
}
