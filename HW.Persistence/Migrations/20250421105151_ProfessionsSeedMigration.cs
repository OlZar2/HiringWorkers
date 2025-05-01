using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProfessionsSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Proffesions",
            columns: ["Id", "Name", "RussianName"],
            values: [Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "plumber", "Сантехник"]);

            migrationBuilder.InsertData(
            table: "Proffesions",
            columns: ["Id", "Name", "RussianName"],
            values: [Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "electrician", "Электрик"]);

            migrationBuilder.InsertData(
            table: "Proffesions",
            columns: ["Id", "Name", "RussianName"],
            values: [Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"), "carpenter", "Плотник"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Proffesions",
            keyColumn: "Id",
            keyValue: Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
            table: "Proffesions",
            keyColumn: "Id",
            keyValue: Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
            table: "Proffesions",
            keyColumn: "Id",
            keyValue: Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"));
        }
    }
}
