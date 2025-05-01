using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProfessionRusNameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RussianName",
                table: "Proffesions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RussianName",
                table: "Proffesions");
        }
    }
}
