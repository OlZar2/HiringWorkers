using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProfessionNullableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Proffesions_ProfessionId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessionId",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Proffesions_ProfessionId",
                table: "Orders",
                column: "ProfessionId",
                principalTable: "Proffesions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Proffesions_ProfessionId",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessionId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Proffesions_ProfessionId",
                table: "Orders",
                column: "ProfessionId",
                principalTable: "Proffesions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
