using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Persistence.Migrations
{
    public partial class AddedNewTrainersAndClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassName", "CreatedOn", "DayOfWeek", "EndTime", "MaxUsers", "PersonalTrainerId", "StartTime", "UpdatedOn" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "Klatka piersiowa", null, 1, new DateTime(2023, 6, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 20, new Guid("00000000-2199-8437-0000-000000000001"), new DateTime(2023, 6, 15, 11, 15, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "PersonalTrainers",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "PhoneNumber", "Surname", "UpdatedOn" },
                values: new object[] { new Guid("12340008-2199-8437-0000-000000003331"), null, "m.koltuniuk@gmail.com", "Mateusz", "666222111", "Kołtuniuk", null });

            migrationBuilder.InsertData(
                table: "PersonalTrainers",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "PhoneNumber", "Surname", "UpdatedOn" },
                values: new object[] { new Guid("33300000-2137-8437-0000-045600000001"), null, "k.konczyński@gmail.com", "Kamil", "533444111", "Kończyński", null });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassName", "CreatedOn", "DayOfWeek", "EndTime", "MaxUsers", "PersonalTrainerId", "StartTime", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Brzuch jak kaloryfer", null, 0, new DateTime(2023, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 20, new Guid("12340008-2199-8437-0000-000000003331"), new DateTime(2023, 6, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Brazylijskie pośladki", null, 3, new DateTime(2023, 6, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 20, new Guid("12340008-2199-8437-0000-000000003331"), new DateTime(2023, 6, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Zumba fitness", null, 4, new DateTime(2023, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 15, new Guid("33300000-2137-8437-0000-045600000001"), new DateTime(2023, 6, 15, 16, 15, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Crossfit", null, 2, new DateTime(2023, 6, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("33300000-2137-8437-0000-045600000001"), new DateTime(2023, 6, 15, 18, 15, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "PersonalTrainers",
                keyColumn: "Id",
                keyValue: new Guid("12340008-2199-8437-0000-000000003331"));

            migrationBuilder.DeleteData(
                table: "PersonalTrainers",
                keyColumn: "Id",
                keyValue: new Guid("33300000-2137-8437-0000-045600000001"));
        }
    }
}
