using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedGymPassPrices3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GymPassPrice",
                table: "GymPassPrice");

            migrationBuilder.RenameTable(
                name: "GymPassPrice",
                newName: "GymPassPrices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymPassPrices",
                table: "GymPassPrices",
                column: "Length");

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 20, 21, 27, 7, 508, DateTimeKind.Local).AddTicks(1717), new DateTime(2023, 11, 20, 21, 27, 7, 508, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 20, 21, 27, 7, 508, DateTimeKind.Local).AddTicks(1721), new DateTime(2023, 11, 20, 21, 27, 7, 508, DateTimeKind.Local).AddTicks(1720) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GymPassPrices",
                table: "GymPassPrices");

            migrationBuilder.RenameTable(
                name: "GymPassPrices",
                newName: "GymPassPrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymPassPrice",
                table: "GymPassPrice",
                column: "Length");

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 20, 20, 58, 17, 60, DateTimeKind.Local).AddTicks(9730), new DateTime(2023, 11, 20, 20, 58, 17, 60, DateTimeKind.Local).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 20, 20, 58, 17, 60, DateTimeKind.Local).AddTicks(9734), new DateTime(2023, 11, 20, 20, 58, 17, 60, DateTimeKind.Local).AddTicks(9733) });
        }
    }
}
