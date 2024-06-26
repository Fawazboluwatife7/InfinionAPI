using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfinionAPI.Migrations
{
    /// <inheritdoc />
    public partial class retestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3249916c-33f7-4f7d-a9af-269566606e65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95d37493-53d0-40f2-aab2-2a04fdd57ad4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "021e0f4e-ce14-45c6-81dd-8786be9fcd7e", "2", "User", "User" },
                    { "f3e10bb2-d641-4f2c-8108-e06af553d294", "1", "InfinionAdmin", "InfinionAdmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "021e0f4e-ce14-45c6-81dd-8786be9fcd7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3e10bb2-d641-4f2c-8108-e06af553d294");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3249916c-33f7-4f7d-a9af-269566606e65", "1", "InfinionAdmin", "InfinionAdmin" },
                    { "95d37493-53d0-40f2-aab2-2a04fdd57ad4", "2", "User", "User" }
                });
        }
    }
}
