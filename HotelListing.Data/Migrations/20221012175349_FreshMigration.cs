using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Data.Migrations
{
    public partial class FreshMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "574f7f58-f542-4238-9d8d-91133ea8eae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5d9f68f-91a8-482e-bfde-f779ee236b3e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ce95416-7c01-4fc9-a3c6-d2e83da71ec5", "19e6a962-09ff-4584-abb6-c4fec4941cda", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de760c47-b847-4f73-acec-54c487924d5c", "2b671e79-dda1-4bbd-ba86-a8d2faa0c708", "Administarator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ce95416-7c01-4fc9-a3c6-d2e83da71ec5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de760c47-b847-4f73-acec-54c487924d5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "574f7f58-f542-4238-9d8d-91133ea8eae7", "478e983e-93df-4d92-a33e-6959c6187dd3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5d9f68f-91a8-482e-bfde-f779ee236b3e", "e7a2e03f-ce77-479b-90b0-852e9c89de6f", "Administarator", "ADMINISTRATOR" });
        }
    }
}
