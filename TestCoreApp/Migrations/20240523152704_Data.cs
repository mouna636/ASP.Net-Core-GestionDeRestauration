

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab77cc61-3e6b-4199-a690-fe589f108f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de83aa06-2a4f-4b6b-906e-a7464197c448");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bde3af4-36eb-461f-baea-f3d9cf5ed91e", "086d24f5-0ef0-4483-b6a6-049ab03d8de9", "User", "user" },
                    { "65b4d897-bae7-4323-850c-baec3df43d5d", "f26fc2b3-4740-451c-b60f-e14ccc910b7e", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bde3af4-36eb-461f-baea-f3d9cf5ed91e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65b4d897-bae7-4323-850c-baec3df43d5d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab77cc61-3e6b-4199-a690-fe589f108f49", "e157466e-6ae3-4f28-af92-eb43cee36d9c", "User", "user" },
                    { "de83aa06-2a4f-4b6b-906e-a7464197c448", "9af11e90-d68d-4b2d-94a9-f9ac6cb5981c", "Admin", "admin" }
                });
        }
    }
}
