using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateComunas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 23,
                column: "CodigoPostalMax",
                value: "8319999");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 23,
                column: "CodigoPostalMax",
                value: "8239999");
        }
    }
}
