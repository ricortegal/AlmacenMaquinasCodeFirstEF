using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPSoluciones.AlmacenMaquinas.Ef.Migrations
{
    /// <inheritdoc />
    public partial class v005_VentaRequeridoArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventas_articulos_NumSerieArticulo",
                table: "ventas");

            migrationBuilder.UpdateData(
                table: "ventas",
                keyColumn: "NumSerieArticulo",
                keyValue: null,
                column: "NumSerieArticulo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NumSerieArticulo",
                table: "ventas",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_articulos_NumSerieArticulo",
                table: "ventas",
                column: "NumSerieArticulo",
                principalTable: "articulos",
                principalColumn: "NumSerie",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ventas_articulos_NumSerieArticulo",
                table: "ventas");

            migrationBuilder.AlterColumn<string>(
                name: "NumSerieArticulo",
                table: "ventas",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ventas_articulos_NumSerieArticulo",
                table: "ventas",
                column: "NumSerieArticulo",
                principalTable: "articulos",
                principalColumn: "NumSerie");
        }
    }
}
