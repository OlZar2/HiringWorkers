using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderProfessionOneToManyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proffesions_Orders_OrderId",
                table: "Proffesions");

            migrationBuilder.DropIndex(
                name: "IX_Proffesions_OrderId",
                table: "Proffesions");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Proffesions");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProfessionId",
                table: "Orders",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Proffesions_ProfessionId",
                table: "Orders",
                column: "ProfessionId",
                principalTable: "Proffesions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Proffesions_ProfessionId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProfessionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Proffesions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proffesions_OrderId",
                table: "Proffesions",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proffesions_Orders_OrderId",
                table: "Proffesions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
