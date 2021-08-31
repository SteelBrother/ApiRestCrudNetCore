using Microsoft.EntityFrameworkCore.Migrations;

namespace TalyCapWEBAPI.Migrations
{
    public partial class Migracion5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiculoEntrega_TipoVehiculoEntrega_IdTipoVehiculoEntregaNavigationId",
                table: "VehiculoEntrega");

            migrationBuilder.RenameColumn(
                name: "IdTipoVehiculoEntregaNavigationId",
                table: "VehiculoEntrega",
                newName: "TipoVehiculoEntregaId");

            migrationBuilder.RenameIndex(
                name: "IX_VehiculoEntrega_IdTipoVehiculoEntregaNavigationId",
                table: "VehiculoEntrega",
                newName: "IX_VehiculoEntrega_TipoVehiculoEntregaId");

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

            migrationBuilder.AddColumn<int>(
                name: "IdTipoLugarEntrega",
                table: "LugarEntrega",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiculoEntrega_TipoVehiculoEntrega_TipoVehiculoEntregaId",
                table: "VehiculoEntrega",
                column: "TipoVehiculoEntregaId",
                principalTable: "TipoVehiculoEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiculoEntrega_TipoVehiculoEntrega_TipoVehiculoEntregaId",
                table: "VehiculoEntrega");

            migrationBuilder.DropColumn(
                name: "IdEntrega",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdRegistro",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdTipoEnvio",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdTipoLugarEntrega",
                table: "LugarEntrega");

            migrationBuilder.RenameColumn(
                name: "TipoVehiculoEntregaId",
                table: "VehiculoEntrega",
                newName: "IdTipoVehiculoEntregaNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_VehiculoEntrega_TipoVehiculoEntregaId",
                table: "VehiculoEntrega",
                newName: "IX_VehiculoEntrega_IdTipoVehiculoEntregaNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiculoEntrega_TipoVehiculoEntrega_IdTipoVehiculoEntregaNavigationId",
                table: "VehiculoEntrega",
                column: "IdTipoVehiculoEntregaNavigationId",
                principalTable: "TipoVehiculoEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
