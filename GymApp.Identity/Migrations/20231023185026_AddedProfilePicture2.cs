using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Identity.Migrations
{
    public partial class AddedProfilePicture2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "d255e96a-90c1-474e-847e-b8bbc9883de5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "48baaebf-1e1f-49d3-80f0-fe8236c46c8b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureId", "SecurityStamp" },
                values: new object[] { "4c88a6b6-3ec7-49aa-b999-b568247353d5", "AQAAAAEAACcQAAAAEHZiojyJZyzOyOWKAxSdPC1DoHfyTPaD6URcAIB8f0szJyW0vAtCOH5bxT07ON9iKw==", new Guid("00000000-0000-0000-0000-000000000001"), "8504dbfe-0da7-491a-8ab7-afa5d69855bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureId", "SecurityStamp" },
                values: new object[] { "b97bdf99-8173-40d7-95e0-233be6d6ebd7", "AQAAAAEAACcQAAAAEJ/jSYMaFoDM1EXNB41beTWPb84RaWHEIvk3BhQCZdiRqZBjAdOOKV7kQb2XQcexqQ==", new Guid("00000000-0000-0000-0000-000000000001"), "d3817e57-20ea-437a-9743-2dff69bc126e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureId", "SecurityStamp" },
                values: new object[] { "225974a7-68b6-4165-b7e5-4b50f9907a6b", "AQAAAAEAACcQAAAAEBU4u2ATF4YV7w3Dk6OdnmP9YPyVtjZ8UWbUuyUwyiAiFYh0rtGJUb7iSSp3L8AiOQ==", new Guid("00000000-0000-0000-0000-000000000000"), "2ad716ac-2101-4055-99cc-1401668d5c59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureId", "SecurityStamp" },
                values: new object[] { "14b0be01-56db-44df-b2dd-877cea4acf24", "AQAAAAEAACcQAAAAEKd/9agisGX8is7L0dhQF4B20nDOGGw5x/HO4JeTXFXfPfteNz63Lj+NRFy7WHMp7w==", new Guid("00000000-0000-0000-0000-000000000000"), "ef197b27-e15a-4311-86e5-43bdef39513f" });
        }
    }
}
