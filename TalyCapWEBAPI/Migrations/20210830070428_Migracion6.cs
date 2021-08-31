using Microsoft.EntityFrameworkCore.Migrations;

namespace TalyCapWEBAPI.Migrations
{
    public partial class Migracion6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEntrega",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdRegistro",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdTipoEnvio",
                table: "Producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEntrega",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRegistro",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoEnvio",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
