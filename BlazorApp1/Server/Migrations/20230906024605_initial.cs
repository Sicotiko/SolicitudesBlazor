using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp1.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comunas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NombreSector = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moviles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    MovilId = table.Column<int>(type: "int", nullable: true),
                    PropiaOAjena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Repartos = table.Column<int>(type: "int", nullable: false),
                    Recogidas = table.Column<int>(type: "int", nullable: false),
                    TipoHorario = table.Column<int>(type: "int", nullable: false),
                    Clasificacion = table.Column<int>(type: "int", nullable: false),
                    ComunaId = table.Column<int>(type: "int", nullable: true),
                    SectorName = table.Column<int>(type: "int", nullable: false),
                    Cerrada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajos_Comunas_ComunaId",
                        column: x => x.ComunaId,
                        principalTable: "Comunas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenTrabajos_Moviles_MovilId",
                        column: x => x.MovilId,
                        principalTable: "Moviles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Comunas",
                columns: new[] { "Id", "CodigoPostal", "Nombre", "NombreSector" },
                values: new object[,]
                {
                    { 1, "9380000", "Lampa", 0 },
                    { 2, "9420000", "TilTil", 0 },
                    { 3, "9480000", "Pirque", 1 },
                    { 4, "8150000", "Puente Alto", 5 },
                    { 5, "9460000", "San José de Maipo", 3 },
                    { 6, "9500000", "Buin", 1 },
                    { 7, "9560000", "Calera de Tango", 3 },
                    { 8, "9540000", "Paine", 1 },
                    { 9, "8050000", "San Bernardo", 3 },
                    { 10, "9650000", "Alhué", 3 },
                    { 11, "9630000", "Curacaví", 3 },
                    { 12, "9620000", "María Pinto", 3 },
                    { 13, "9580000", "Melipilla", 3 },
                    { 14, "9660000", "San Pedro", 3 },
                    { 15, "9200000", "Cerrillos", 5 },
                    { 16, "9080000", "Cerro Navia", 0 },
                    { 17, "8540000", "Conchalí", 0 },
                    { 18, "8010000", "El Bosque", 1 },
                    { 19, "9160000", "Estación Central", 0 },
                    { 20, "8580000", "Huechuraba", 0 },
                    { 21, "8380000", "Independencia", 0 },
                    { 22, "7970000", "La Cisterna", 1 },
                    { 23, "8240000", "La Florida", 5 },
                    { 24, "8780000", "La Granja", 5 },
                    { 25, "8820000", "La Pintana", 5 },
                    { 26, "7850000", "La Reina", 5 },
                    { 27, "7550000", "Las Condes", 5 },
                    { 28, "7690000", "Lo Barnechea", 5 },
                    { 29, "9120000", "Lo Espejo", 1 },
                    { 30, "8980000", "Lo Prado", 0 },
                    { 31, "7810000", "Macul", 5 },
                    { 32, "9250000", "Maipú", 5 },
                    { 33, "7750000", "Ñuñoa", 5 },
                    { 34, "8460000", "Pedro Aguirre Cerda", 1 },
                    { 35, "7910000", "Peñalolén", 5 },
                    { 36, "7500000", "Providencia", 5 },
                    { 37, "9020000", "Pudahuel", 0 },
                    { 38, "8700000", "Quilicura", 0 },
                    { 39, "8500000", "Quinta Normal", 0 },
                    { 40, "8420000", "Recoleta", 0 },
                    { 41, "8640000", "Renca", 0 },
                    { 42, "8940000", "San Joaquín", 5 },
                    { 43, "8900000", "San Miguel", 1 },
                    { 44, "8860000", "San Ramón", 5 },
                    { 45, "8320000", "Santiago", 2 },
                    { 46, "7630000", "Vitacura", 5 },
                    { 47, "9810000", "El Monte", 3 },
                    { 48, "9790000", "Isla de Maipo", 3 },
                    { 49, "9710000", "Padre Hurtado", 5 },
                    { 50, "9750000", "Peñaflor", 3 },
                    { 51, "9670000", "Talagante", 1 },
                    { 52, "2660000", "San Antonio", 4 },
                    { 53, "2710000", "Algarrobo", 4 },
                    { 54, "2680000", "Cartagena", 4 },
                    { 55, "2690000", "El Tabo", 4 },
                    { 56, "2700000", "El Quisco", 4 },
                    { 57, "2720000", "Santo Domingo", 4 },
                    { 58, "9340000", "Colina", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comunas_CodigoPostal",
                table: "Comunas",
                column: "CodigoPostal",
                unique: true,
                filter: "[CodigoPostal] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajos_ComunaId",
                table: "OrdenTrabajos",
                column: "ComunaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajos_MovilId",
                table: "OrdenTrabajos",
                column: "MovilId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajos_Numero",
                table: "OrdenTrabajos",
                column: "Numero",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenTrabajos");

            migrationBuilder.DropTable(
                name: "Comunas");

            migrationBuilder.DropTable(
                name: "Moviles");
        }
    }
}
