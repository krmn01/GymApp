using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedUsersProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassUsersProfile",
                columns: table => new
                {
                    ClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassUsersProfile", x => new { x.ClassesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ClassUsersProfile_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassUsersProfile_UsersProfiles_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UsersProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGoals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    UsersProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingGoals_UsersProfiles_UsersProfileId",
                        column: x => x.UsersProfileId,
                        principalTable: "UsersProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "UsersProfiles",
                columns: new[] { "Id", "CreatedOn", "ProfileDescription", "ProfilePictureId", "UpdatedOn", "UsersId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), null, "", new Guid("00000000-0000-0000-0000-000000000001"), null, "753caff9-598a-42d9-aa00-bfa3be83096a" });

            migrationBuilder.InsertData(
                table: "UsersProfiles",
                columns: new[] { "Id", "CreatedOn", "ProfileDescription", "ProfilePictureId", "UpdatedOn", "UsersId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), null, "", new Guid("00000000-0000-0000-0000-000000000001"), null, "4a60b6be-42d4-4676-86ef-bbfe129011da" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsersProfile_UsersId",
                table: "ClassUsersProfile",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoals_UsersProfileId",
                table: "TrainingGoals",
                column: "UsersProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassUsersProfile");

            migrationBuilder.DropTable(
                name: "TrainingGoals");

            migrationBuilder.DropTable(
                name: "UsersProfiles");
        }
    }
}
