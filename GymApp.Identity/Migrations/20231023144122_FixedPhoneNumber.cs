using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Identity.Migrations
{
    public partial class FixedPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "84a33f4a-a154-4a1b-a3bb-dbf774c3216b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "81145670-ce46-4e0b-a01d-0c79a18707d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "2c84b631-88b1-42ec-b022-028ab1dff53d", "AQAAAAEAACcQAAAAEJ+NewWdpY/7eCosKpwNNxxB7vTIL76YJfPEGP4pzy+b19iY832aFrgV4KYBNv+92g==", "", "cd959487-7b5b-4e99-b561-ac96674f1bcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "bf7e6c42-0e6f-4854-99ab-7811760976c1", "AQAAAAEAACcQAAAAELZs3Rka4lIlISlrmBJKf8v/pj4JsDO702Zr6YkrQQBtJVuqSQ846ilWlcYjkpF0Vg==", "", "e6bcd246-1e66-49e9-a129-e63dca7bf029" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl2137-2222-4448-beef-1add431acrcl",
                column: "ConcurrencyStamp",
                value: "72fed7ff-4c48-4745-85ff-f56d6d8a1fa2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "crcl3317-2222-4445-beef-1add431fcrcl",
                column: "ConcurrencyStamp",
                value: "330f17f0-3ce5-4891-bc72-842b3fe5bf93");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a60b6be-42d4-4676-86ef-bbfe129011da",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "2d398d9d-d21e-488f-83a2-d48c6c453611", "AQAAAAEAACcQAAAAEFzAgaWgXjVvu3p291lpF6O71W8KkZGpMngYRSfvx5yms/SRyXf33STYBFD2kB8lGw==", null, "80d7db0d-fe55-4835-9aec-e5ccabddb6b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753caff9-598a-42d9-aa00-bfa3be83096a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "dfa7f00d-37bf-448b-88e6-971188eb3e91", "AQAAAAEAACcQAAAAEBOm3U5BpXCGpnElrUbuQQvFfZgtEQSQF8HeMpxRBbCNVHL2mWKXeacQRFArlolC5Q==", null, "8503ef30-7cf2-4b95-9fa9-d29e807b4c66" });
        }
    }
}
