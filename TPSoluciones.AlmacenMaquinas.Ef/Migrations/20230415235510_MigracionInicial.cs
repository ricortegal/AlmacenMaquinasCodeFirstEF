using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPSoluciones.AlmacenMaquinas.Ef.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "almacen_ubicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pasillo = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estanteria = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Posicion = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_almacen_ubicaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Poblacion = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "articulos",
                columns: table => new
                {
                    NumSerie = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotasFabricacion = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotasRecepcion = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotasInstalacion = table.Column<string>(type: "TINYTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaFabricacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaInstalacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdUbicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articulos", x => x.NumSerie);
                    table.ForeignKey(
                        name: "FK_articulos_almacen_ubicaciones_IdUbicacion",
                        column: x => x.IdUbicacion,
                        principalTable: "almacen_ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articulos_productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    NumSerieArticulo = table.Column<string>(type: "varchar(15)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ventas_articulos_NumSerieArticulo",
                        column: x => x.NumSerieArticulo,
                        principalTable: "articulos",
                        principalColumn: "NumSerie");
                    table.ForeignKey(
                        name: "FK_ventas_clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_articulos_IdProducto",
                table: "articulos",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_articulos_IdUbicacion",
                table: "articulos",
                column: "IdUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_productos_Codigo",
                table: "productos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_IdCliente",
                table: "ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_NumSerieArticulo",
                table: "ventas",
                column: "NumSerieArticulo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "articulos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "almacen_ubicaciones");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
