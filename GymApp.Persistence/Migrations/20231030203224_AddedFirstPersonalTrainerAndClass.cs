using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedFirstPersonalTrainerAndClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingGoals_UsersProfiles_UsersProfileId",
                table: "TrainingGoals");

            migrationBuilder.DropIndex(
                name: "IX_TrainingGoals_UsersProfileId",
                table: "TrainingGoals");

            migrationBuilder.DropColumn(
                name: "UsersProfileId",
                table: "TrainingGoals");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "TrainingGoals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Classes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaxUsers",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Classes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "PersonalTrainers",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "PhoneNumber", "Surname", "UpdatedOn" },
                values: new object[] { new Guid("00000000-2199-8437-0000-000000000001"), null, "l.karasek@gmail.com", "Łukasz", "533222111", "Karasek", null });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassName", "CreatedOn", "EndTime", "MaxUsers", "PersonalTrainerId", "StartTime", "UpdatedOn" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Żelazne barki", null, new DateTime(2023, 6, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), 20, new Guid("00000000-2199-8437-0000-000000000001"), new DateTime(2023, 6, 15, 21, 15, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoals_ProfileId",
                table: "TrainingGoals",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingGoals_UsersProfiles_ProfileId",
                table: "TrainingGoals",
                column: "ProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingGoals_UsersProfiles_ProfileId",
                table: "TrainingGoals");

            migrationBuilder.DropIndex(
                name: "IX_TrainingGoals_ProfileId",
                table: "TrainingGoals");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "PersonalTrainers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-2199-8437-0000-000000000001"));

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "TrainingGoals");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "MaxUsers",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Classes");

            migrationBuilder.AddColumn<Guid>(
                name: "UsersProfileId",
                table: "TrainingGoals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoals_UsersProfileId",
                table: "TrainingGoals",
                column: "UsersProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingGoals_UsersProfiles_UsersProfileId",
                table: "TrainingGoals",
                column: "UsersProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id");
        }
    }
}
