using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class RepairedClassUsersProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_PersonalTrainers_PersonalTrainerId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassUsersProfile_Classes_ClassesId",
                table: "ClassUsersProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_PersonalTrainerId",
                table: "Class",
                newName: "IX_Class_PersonalTrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_PersonalTrainers_PersonalTrainerId",
                table: "Class",
                column: "PersonalTrainerId",
                principalTable: "PersonalTrainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassUsersProfile_Class_ClassesId",
                table: "ClassUsersProfile",
                column: "ClassesId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_PersonalTrainers_PersonalTrainerId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassUsersProfile_Class_ClassesId",
                table: "ClassUsersProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");

            migrationBuilder.RenameIndex(
                name: "IX_Class_PersonalTrainerId",
                table: "Classes",
                newName: "IX_Classes_PersonalTrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_PersonalTrainers_PersonalTrainerId",
                table: "Classes",
                column: "PersonalTrainerId",
                principalTable: "PersonalTrainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassUsersProfile_Classes_ClassesId",
                table: "ClassUsersProfile",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
