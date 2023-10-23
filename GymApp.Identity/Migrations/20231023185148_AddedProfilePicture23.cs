using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Identity.Migrations
{
    public partial class AddedProfilePicture23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "5ca8fa02-9b01-4e33-99b7-2c141fbb4303");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "b7a0ed92-65b3-488a-8b6a-4535af420cb3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "179b64a2-e9b9-4eef-877e-cf7d7c1bb8c5", "AQAAAAEAACcQAAAAEOwzQ9HoBSBUSNqjCsufiMiC4vjV1qq+qnlVUkRZwGxQeYKQ2vfcTwz7yqY8c0lqNg==", "257de1f4-82a3-4d9f-a8b1-9222c6216a3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cfcadb2-68a5-4256-af7d-6f7d9e77d7a1", "AQAAAAEAACcQAAAAEKsnKPz+C7BdJjWRL2zDZvOvrlpjzX+juAHZJSnPniLSJoPCzwE5weiZxKxgqmg9rQ==", "a2148155-807e-4fb0-ac50-0c10bebd593c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c88a6b6-3ec7-49aa-b999-b568247353d5", "AQAAAAEAACcQAAAAEHZiojyJZyzOyOWKAxSdPC1DoHfyTPaD6URcAIB8f0szJyW0vAtCOH5bxT07ON9iKw==", "8504dbfe-0da7-491a-8ab7-afa5d69855bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b97bdf99-8173-40d7-95e0-233be6d6ebd7", "AQAAAAEAACcQAAAAEJ/jSYMaFoDM1EXNB41beTWPb84RaWHEIvk3BhQCZdiRqZBjAdOOKV7kQb2XQcexqQ==", "d3817e57-20ea-437a-9743-2dff69bc126e" });
        }
    }
}
