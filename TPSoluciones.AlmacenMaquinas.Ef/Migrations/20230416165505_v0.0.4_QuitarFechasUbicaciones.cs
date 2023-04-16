using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPSoluciones.AlmacenMaquinas.Ef.Migrations
{
    /// <inheritdoc />
    public partial class v004_QuitarFechasUbicaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaEntrada",
                table: "almacen_ubicaciones");

            migrationBuilder.DropColumn(
                name: "FechaSalida",
                table: "almacen_ubicaciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrada",
                table: "almacen_ubicaciones",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalida",
                table: "almacen_ubicaciones",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
