using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43141cc3-97a3-4574-8451-a93e814f13f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1a8b70c-9eaf-4ce1-b086-eff753c9c09d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76250921-86b4-40bb-83dd-a1b51aa9aa6b", "575046d6-a839-416c-8dce-9dba8ce449fc", "Admin", "admin" },
                    { "807e992f-0f18-4f56-9053-c1d1f4ab20ba", "f88059e6-67ea-4310-a1ef-fa182d878e18", "User", "user" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Italien Food");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Chinese Food");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Tunisian Food");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76250921-86b4-40bb-83dd-a1b51aa9aa6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "807e992f-0f18-4f56-9053-c1d1f4ab20ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43141cc3-97a3-4574-8451-a93e814f13f6", "d94d5b68-405d-4fcc-806e-a79c8c72ebe4", "User", "user" },
                    { "e1a8b70c-9eaf-4ce1-b086-eff753c9c09d", "7c5caded-7041-45de-951b-52c78afe3c30", "Admin", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Computers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Mobiles");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Electric machines");
        }
    }
}
