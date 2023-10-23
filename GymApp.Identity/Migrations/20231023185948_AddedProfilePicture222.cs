using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Identity.Migrations
{
    public partial class AddedProfilePicture222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "afb01289-d794-49d0-8950-584fb9002439");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "024de541-a5ed-4eaf-9e17-5de0ef99cfa7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "446cab56-99c5-45f3-a074-89f7379eedae", "AQAAAAEAACcQAAAAEMHGrE8UN0g/BvnhIHt+p9LQ4f7jmImroXd4IlssTp2Wt9Iv40St2C4I7bjFr+49JA==", "f70135af-3a08-4268-bf48-bf4a582cd0a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed536b00-2700-4dc5-9178-291f17429f21", "AQAAAAEAACcQAAAAEFBM8OUYWDNlOJ1feJVmmyAMKwTFCE7Aj3s12sWeYML5y+AUYurafYuDjWdUbEtE+w==", "c8ea94b7-b468-4f41-a197-ff3a28f845bd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
