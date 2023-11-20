using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedGymPassPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassType",
                table: "GymPasses");

            migrationBuilder.CreateTable(
                name: "GymPassPrice",
                columns: table => new
                {
                    GymPassLength = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPassPrice", x => x.GymPassLength);
                });

            migrationBuilder.InsertData(
                table: "GymPassPrice",
                columns: new[] { "GymPassLength", "Price" },
                values: new object[,]
                {
                    { 0, 99m },
                    { 1, 250m },
                    { 2, 450m },
                    { 3, 850m }
                });

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 20, 20, 50, 32, 216, DateTimeKind.Local).AddTicks(5443), new DateTime(2023, 11, 20, 20, 50, 32, 216, DateTimeKind.Local).AddTicks(5411) });

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 20, 20, 50, 32, 216, DateTimeKind.Local).AddTicks(5447), new DateTime(2023, 11, 20, 20, 50, 32, 216, DateTimeKind.Local).AddTicks(5446) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymPassPrice");

            migrationBuilder.AddColumn<int>(
                name: "PassType",
                table: "GymPasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 8, 23, 28, 56, 484, DateTimeKind.Local).AddTicks(95), new DateTime(2023, 11, 8, 23, 28, 56, 484, DateTimeKind.Local).AddTicks(62) });

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 8, 23, 28, 56, 484, DateTimeKind.Local).AddTicks(100), new DateTime(2023, 11, 8, 23, 28, 56, 484, DateTimeKind.Local).AddTicks(99) });
        }
    }
}
