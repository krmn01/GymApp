using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Identity.Migrations
{
    public partial class AddedProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePictureId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "9a5d42d2-16dc-4410-91cb-e0ce965b0db1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "b162354a-6266-46e2-95b5-3a9a7cfb739c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c1001fe-ebd9-42ac-b895-090a425d76e5", "AQAAAAEAACcQAAAAELMaQg4DeWOzGMUNf7smFMWr6c7XSaxgSwCgLjYONwW/yUaHgaslO7cMr3aVbme9mA==", "d73a64a4-66ae-4591-beb3-1f31ed4306e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "188da4a9-99e0-44fb-a2a4-4e3e038cbf49", "AQAAAAEAACcQAAAAEDn0ijxDCqqmTrP6n4rQEMtwzsodn4PG4Trz3tRg1gbePK8ys14prDYdRNhKsVMTlw==", "ef440763-3a04-4c38-8629-9dc37d238134" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "84a33f4a-a154-4a1b-a3bb-dbf774c3216b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "81145670-ce46-4e0b-a01d-0c79a18707d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c84b631-88b1-42ec-b022-028ab1dff53d", "AQAAAAEAACcQAAAAEJ+NewWdpY/7eCosKpwNNxxB7vTIL76YJfPEGP4pzy+b19iY832aFrgV4KYBNv+92g==", "cd959487-7b5b-4e99-b561-ac96674f1bcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf7e6c42-0e6f-4854-99ab-7811760976c1", "AQAAAAEAACcQAAAAELZs3Rka4lIlISlrmBJKf8v/pj4JsDO702Zr6YkrQQBtJVuqSQ846ilWlcYjkpF0Vg==", "e6bcd246-1e66-49e9-a129-e63dca7bf029" });
        }
    }
}
