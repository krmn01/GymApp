using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedGymPassPrices2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GymPassLength",
                table: "GymPassPrice",
                newName: "Length");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Length",
                table: "GymPassPrice",
                newName: "GymPassLength");

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
    }
}
