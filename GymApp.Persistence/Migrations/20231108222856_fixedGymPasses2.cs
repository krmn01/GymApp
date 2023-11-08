using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class fixedGymPasses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 8, 20, 46, 54, 506, DateTimeKind.Local).AddTicks(9548), new DateTime(2023, 11, 8, 20, 46, 54, 506, DateTimeKind.Local).AddTicks(9513) });

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 8, 20, 46, 54, 506, DateTimeKind.Local).AddTicks(9552), new DateTime(2023, 11, 8, 20, 46, 54, 506, DateTimeKind.Local).AddTicks(9551) });
        }
    }
}
