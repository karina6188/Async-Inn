using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class addedSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "ID", "City", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Coronado", "Curio del Coronado", "(619)435-6611", "CA", "1500 Orange Ave" },
                    { 2, "Santa Monica", "Shutters on the Beach", "(310)458-0030", "CA", "1 Pico Blvd" },
                    { 3, "New York", "Four Seasons", "(212)758-5700", "NY", "57 E 57th St" },
                    { 4, "Chicago", "The Langham", "(312)923-9988", "IL", "330 N Wabash Ave" },
                    { 5, "San Francisco", "Fairmont Heritage", "(415)268-9900", "CA", "900 North Point St" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
