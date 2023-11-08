using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class fixedGymPasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3093), new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3062) });

            migrationBuilder.UpdateData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "StartedOn", "ValidTill" },
                values: new object[] { new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3098), new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3096) });
        }
    }
}
