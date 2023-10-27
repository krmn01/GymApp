using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Identity.Migrations
{
    public partial class AddedUsersProfile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePictureId",
                table: "AspNetUsers",
                newName: "UserProfileId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "6997f271-c5dd-481a-a4ad-29d1ff2d5562");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "a11a76d9-dd74-49fe-97ad-76d6db5b9fef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserProfileId" },
                values: new object[] { "149c8873-3031-4a0f-94b2-1c037d5544df", "AQAAAAEAACcQAAAAEJrh72Mu8uyqneT69O/uIat3sWyQcChuHS6bb241SkLgEtuD0d9nxR2ChCYU3QQyAg==", "be1c824c-f463-4d30-8d06-7a0ba7e5b702", new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecf1daf1-189a-4940-be25-46c762a0d6c2", "AQAAAAEAACcQAAAAEE3HdMBo98egp+w38vPFp3hXyE5t9uJSG7dThp+MbB/85U7aI+TOMBz+/+mWGNci+g==", "f7842a86-9b89-4d15-8270-da02abf7e040" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "AspNetUsers",
                newName: "ProfilePictureId");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureId", "SecurityStamp" },
                values: new object[] { "446cab56-99c5-45f3-a074-89f7379eedae", "AQAAAAEAACcQAAAAEMHGrE8UN0g/BvnhIHt+p9LQ4f7jmImroXd4IlssTp2Wt9Iv40St2C4I7bjFr+49JA==", new Guid("00000000-0000-0000-0000-000000000001"), "f70135af-3a08-4268-bf48-bf4a582cd0a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed536b00-2700-4dc5-9178-291f17429f21", "AQAAAAEAACcQAAAAEFBM8OUYWDNlOJ1feJVmmyAMKwTFCE7Aj3s12sWeYML5y+AUYurafYuDjWdUbEtE+w==", "c8ea94b7-b468-4f41-a197-ff3a28f845bd" });
        }
    }
}
