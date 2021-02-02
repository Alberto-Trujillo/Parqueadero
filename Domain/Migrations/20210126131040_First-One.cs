using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class FirstOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parqueaderos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parqueaderos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PicoPlacas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicoPlacas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    Cilindraje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    Parqueadero = table.Column<short>(type: "smallint", nullable: false),
                    Hora_Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora_Salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobros_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parqueaderos",
                columns: new[] { "Id", "Disponible", "TipoVehiculo" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 30, 1, 1 },
                    { 29, 1, 1 },
                    { 28, 1, 1 },
                    { 27, 1, 1 },
                    { 26, 1, 1 },
                    { 24, 1, 1 },
                    { 23, 1, 1 },
                    { 22, 1, 1 },
                    { 21, 1, 1 },
                    { 20, 1, 0 },
                    { 19, 1, 0 },
                    { 18, 1, 0 },
                    { 17, 1, 0 },
                    { 16, 1, 0 },
                    { 25, 1, 1 },
                    { 14, 1, 0 },
                    { 15, 1, 0 },
                    { 2, 1, 0 },
                    { 3, 1, 0 },
                    { 5, 1, 0 },
                    { 6, 1, 0 },
                    { 7, 1, 0 },
                    { 4, 1, 0 },
                    { 9, 1, 0 },
                    { 10, 1, 0 },
                    { 11, 1, 0 },
                    { 12, 1, 0 },
                    { 13, 1, 0 },
                    { 8, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "PicoPlacas",
                columns: new[] { "Id", "Dia", "Numero" },
                values: new object[,]
                {
                    { 18, 0, (short)7 },
                    { 11, 6, (short)0 },
                    { 17, 0, (short)6 },
                    { 16, 0, (short)5 },
                    { 15, 6, (short)4 },
                    { 14, 6, (short)3 },
                    { 13, 6, (short)2 },
                    { 12, 6, (short)1 },
                    { 10, 5, (short)9 },
                    { 3, 2, (short)2 },
                    { 8, 4, (short)7 },
                    { 7, 4, (short)6 }
                });

            migrationBuilder.InsertData(
                table: "PicoPlacas",
                columns: new[] { "Id", "Dia", "Numero" },
                values: new object[,]
                {
                    { 6, 3, (short)5 },
                    { 5, 3, (short)4 },
                    { 4, 2, (short)3 },
                    { 2, 1, (short)1 },
                    { 1, 1, (short)0 },
                    { 19, 0, (short)8 },
                    { 9, 5, (short)8 },
                    { 20, 0, (short)9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_VehiculoId",
                table: "Cobros",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Parqueaderos");

            migrationBuilder.DropTable(
                name: "PicoPlacas");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
