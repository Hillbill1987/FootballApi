using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballApi.Migrations
{
    /// <inheritdoc />
    public partial class added_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "Id", "Age", "Name", "Nationality", "Team" },
                values: new object[,]
                {
                    { 1, 23, "Dave Rogers", "Scottish", "Rushie United" },
                    { 2, 30, "Jimmy Fred", "French", "Astro Rovers" },
                    { 3, 27, "Roy Kollow", "Danish", "Red Warriors" }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "Id", "Country", "Manager", "Name", "YearFounded" },
                values: new object[,]
                {
                    { 1, "France", "Mr T", "Yuko warriors", 1945 },
                    { 2, "England", "Mr Q", "Green Lamp United", 1890 },
                    { 3, "Brazil", "Mr Z", "Red Sea United", 1956 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
