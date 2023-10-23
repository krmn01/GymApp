using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Identity.Migrations
{
    public partial class AddedProfilePicture1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "bacef2ad-c432-4dab-ac33-52b803b7fd17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "8b999e35-f735-47ab-b300-a75428444ebe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "225974a7-68b6-4165-b7e5-4b50f9907a6b", "AQAAAAEAACcQAAAAEBU4u2ATF4YV7w3Dk6OdnmP9YPyVtjZ8UWbUuyUwyiAiFYh0rtGJUb7iSSp3L8AiOQ==", "2ad716ac-2101-4055-99cc-1401668d5c59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14b0be01-56db-44df-b2dd-877cea4acf24", "AQAAAAEAACcQAAAAEKd/9agisGX8is7L0dhQF4B20nDOGGw5x/HO4JeTXFXfPfteNz63Lj+NRFy7WHMp7w==", "ef197b27-e15a-4311-86e5-43bdef39513f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
