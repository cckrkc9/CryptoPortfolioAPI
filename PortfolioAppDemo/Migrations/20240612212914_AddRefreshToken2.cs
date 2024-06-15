using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioAppDemo.Migrations
{
    public partial class AddRefreshToken2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24de11da-6b6a-45df-9aa0-3c19a6817e87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "550ea895-e549-407c-a713-90876b83a085");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "508fe1df-10dd-49d3-9b23-7cb29aa4e3da", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b5d007d-476d-4c3c-b02b-897cf3d8a8d2", null, "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "508fe1df-10dd-49d3-9b23-7cb29aa4e3da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b5d007d-476d-4c3c-b02b-897cf3d8a8d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24de11da-6b6a-45df-9aa0-3c19a6817e87", null, "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "550ea895-e549-407c-a713-90876b83a085", null, "Admin", "ADMIN" });
        }
    }
}
