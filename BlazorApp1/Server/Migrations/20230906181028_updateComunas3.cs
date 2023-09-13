using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateComunas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comunas_CodigoPostal",
                table: "Comunas");

            migrationBuilder.AlterColumn<int>(
                name: "CodigoPostalMax",
                table: "Comunas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CodigoPostal",
                table: "Comunas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9380000, 9419999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9420000, 9459999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9480000, 9499999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8150000, 8239999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9460000, 9479999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9500000, 9539999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9560000, 9579999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9540000, 9559999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8050000, 8149999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9650000, 9659999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9630000, 9649999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9620000, 9629999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9580000, 9619999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9660000, 9669999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9200000, 9249999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9080000, 9119999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8540000, 8579999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8010000, 8049999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9160000, 9199999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8580000, 8639999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8380000, 8419999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7970000, 8009999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8240000, 8319999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8780000, 8819999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8820000, 8859999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7850000, 7909999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7550000, 7629999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7690000, 7749999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9120000, 9159999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8980000, 9019999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7810000, 7849999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9250000, 9339999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7750000, 7809999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8460000, 8499999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7910000, 7969999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7500000, 7549999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9020000, 9079999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8700000, 8779999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8500000, 8539999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8420000, 8459999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8640000, 8699999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8940000, 8979999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8900000, 8939999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8860000, 8899999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 8320000, 8379999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 7630000, 7689999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9810000, 9999999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9790000, 9809999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9710000, 9749999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9750000, 9789999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9670000, 9709999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 2660000, 2679999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 2710000, 2719999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 2680000, 2689999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 2690000, 2699999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 2700000, 2709999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 2720000, 7499999 });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { 9340000, 9379999 });

            migrationBuilder.CreateIndex(
                name: "IX_Comunas_CodigoPostal",
                table: "Comunas",
                column: "CodigoPostal",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comunas_CodigoPostal",
                table: "Comunas");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostalMax",
                table: "Comunas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPostal",
                table: "Comunas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9380000", "9419999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9420000", "9459999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9480000", "9499999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8150000", "8239999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9460000", "9479999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9500000", "9539999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9560000", "9579999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9540000", "9559999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8050000", "8149999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9650000", "9659999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9630000", "9649999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9620000", "9629999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9580000", "9619999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9660000", "9669999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9200000", "9249999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9080000", "9119999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8540000", "8579999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8010000", "8049999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9160000", "9199999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8580000", "8639999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8380000", "8419999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7970000", "8009999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8240000", "8319999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8780000", "8819999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8820000", "8859999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7850000", "7909999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7550000", "7629999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7690000", "7749999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9120000", "9159999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8980000", "9019999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7810000", "7849999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9250000", "9339999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7750000", "7809999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8460000", "8499999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7910000", "7969999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7500000", "7549999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9020000", "9079999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8700000", "8779999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8500000", "8539999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8420000", "8459999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8640000", "8699999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8940000", "8979999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8900000", "8939999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8860000", "8899999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "8320000", "8379999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "7630000", "7689999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9810000", "9999999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9790000", "9809999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9710000", "9749999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9750000", "9789999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9670000", "9709999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "2660000", "2679999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "2710000", "2719999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "2680000", "2689999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "2690000", "2699999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "2700000", "2709999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "2720000", "7499999" });

            migrationBuilder.UpdateData(
                table: "Comunas",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CodigoPostal", "CodigoPostalMax" },
                values: new object[] { "9340000", "9379999" });

            migrationBuilder.CreateIndex(
                name: "IX_Comunas_CodigoPostal",
                table: "Comunas",
                column: "CodigoPostal",
                unique: true,
                filter: "[CodigoPostal] IS NOT NULL");
        }
    }
}
