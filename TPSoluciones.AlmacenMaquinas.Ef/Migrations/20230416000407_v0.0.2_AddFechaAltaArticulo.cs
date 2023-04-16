using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPSoluciones.AlmacenMaquinas.Ef.Migrations
{
    /// <inheritdoc />
    public partial class v002_AddFechaAltaArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                table: "productos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaAlta",
                table: "productos");
        }
    }
}
