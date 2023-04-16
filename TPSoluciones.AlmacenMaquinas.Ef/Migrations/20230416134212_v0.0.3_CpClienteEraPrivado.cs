using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPSoluciones.AlmacenMaquinas.Ef.Migrations
{
    /// <inheritdoc />
    public partial class v003_CpClienteEraPrivado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cp",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cp",
                table: "clientes");
        }
    }
}
