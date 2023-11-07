using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedDefaultGymPasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymPasses_UsersProfiles_UserId",
                table: "GymPasses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GymPasses",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_GymPasses_UserId",
                table: "GymPasses",
                newName: "IX_GymPasses_ProfileId");

            migrationBuilder.AddColumn<Guid>(
                name: "GymPassId",
                table: "UsersProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "GymPasses",
                columns: new[] { "Id", "CreatedOn", "PassType", "ProfileId", "StartedOn", "UpdatedOn", "ValidTill" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, 0, new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3093), null, new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3062) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), null, 0, new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3098), null, new DateTime(2023, 11, 7, 21, 37, 8, 21, DateTimeKind.Local).AddTicks(3096) }
                });

            migrationBuilder.UpdateData(
                table: "UsersProfiles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "GymPassId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "UsersProfiles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "GymPassId",
                value: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.AddForeignKey(
                name: "FK_GymPasses_UsersProfiles_ProfileId",
                table: "GymPasses",
                column: "ProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymPasses_UsersProfiles_ProfileId",
                table: "GymPasses");

            migrationBuilder.DeleteData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "GymPasses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DropColumn(
                name: "GymPassId",
                table: "UsersProfiles");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "GymPasses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GymPasses_ProfileId",
                table: "GymPasses",
                newName: "IX_GymPasses_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymPasses_UsersProfiles_UserId",
                table: "GymPasses",
                column: "UserId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
