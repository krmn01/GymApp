using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedGymPassesAndEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymPasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidTill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PassType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymPasses_UsersProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GymEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GymPassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnteredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExitedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymEntries_GymPasses_GymPassId",
                        column: x => x.GymPassId,
                        principalTable: "GymPasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymEntries_GymPassId",
                table: "GymEntries",
                column: "GymPassId");

            migrationBuilder.CreateIndex(
                name: "IX_GymPasses_UserId",
                table: "GymPasses",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymEntries");

            migrationBuilder.DropTable(
                name: "GymPasses");
        }
    }
}
