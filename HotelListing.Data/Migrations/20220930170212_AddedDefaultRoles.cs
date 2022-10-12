using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.Data.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "574f7f58-f542-4238-9d8d-91133ea8eae7", "478e983e-93df-4d92-a33e-6959c6187dd3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5d9f68f-91a8-482e-bfde-f779ee236b3e", "e7a2e03f-ce77-479b-90b0-852e9c89de6f", "Administarator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "574f7f58-f542-4238-9d8d-91133ea8eae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5d9f68f-91a8-482e-bfde-f779ee236b3e");
        }
    }
}
