using Microsoft.EntityFrameworkCore.Migrations;

namespace TalyCapWEBAPI.Migrations
{
    public partial class Migracion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_LugarEntrega_LugarEntregaId",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Entrega_IdEntregaNavigationId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Registro_IdRegistroNavigationId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoEnvio_IdTipoEnvioNavigationId",
                table: "Producto");

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
                name: "IdTipoEnvioNavigationId",
                table: "Producto",
                newName: "TipoEnvioId");

            migrationBuilder.RenameColumn(
                name: "IdRegistroNavigationId",
                table: "Producto",
                newName: "RegistroId");

            migrationBuilder.RenameColumn(
                name: "IdEntregaNavigationId",
                table: "Producto",
                newName: "EntregaId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_IdTipoEnvioNavigationId",
                table: "Producto",
                newName: "IX_Producto_TipoEnvioId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_IdRegistroNavigationId",
                table: "Producto",
                newName: "IX_Producto_RegistroId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_IdEntregaNavigationId",
                table: "Producto",
                newName: "IX_Producto_EntregaId");

            migrationBuilder.RenameColumn(
                name: "LugarEntregaId",
                table: "Entrega",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrega_LugarEntregaId",
                table: "Entrega",
                newName: "IX_Entrega_ClienteId");

            migrationBuilder.CreateTable(
                name: "EntregaLugarEntrega",
                columns: table => new
                {
                    EntregasId = table.Column<int>(type: "int", nullable: false),
                    LugarEntregaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaLugarEntrega", x => new { x.EntregasId, x.LugarEntregaId });
                    table.ForeignKey(
                        name: "FK_EntregaLugarEntrega_Entrega_EntregasId",
                        column: x => x.EntregasId,
                        principalTable: "Entrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntregaLugarEntrega_LugarEntrega_LugarEntregaId",
                        column: x => x.LugarEntregaId,
                        principalTable: "LugarEntrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaLugarEntrega_LugarEntregaId",
                table: "EntregaLugarEntrega",
                column: "LugarEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_Cliente_ClienteId",
                table: "Entrega",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Entrega_EntregaId",
                table: "Producto",
                column: "EntregaId",
                principalTable: "Entrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Registro_RegistroId",
                table: "Producto",
                column: "RegistroId",
                principalTable: "Registro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoEnvio_TipoEnvioId",
                table: "Producto",
                column: "TipoEnvioId",
                principalTable: "TipoEnvio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Cliente_ClienteId",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Entrega_EntregaId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Registro_RegistroId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_TipoEnvio_TipoEnvioId",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "EntregaLugarEntrega");

            migrationBuilder.RenameColumn(
                name: "TipoEnvioId",
                table: "Producto",
                newName: "IdTipoEnvioNavigationId");

            migrationBuilder.RenameColumn(
                name: "RegistroId",
                table: "Producto",
                newName: "IdRegistroNavigationId");

            migrationBuilder.RenameColumn(
                name: "EntregaId",
                table: "Producto",
                newName: "IdEntregaNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_TipoEnvioId",
                table: "Producto",
                newName: "IX_Producto_IdTipoEnvioNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_RegistroId",
                table: "Producto",
                newName: "IX_Producto_IdRegistroNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_EntregaId",
                table: "Producto",
                newName: "IX_Producto_IdEntregaNavigationId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Entrega",
                newName: "LugarEntregaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrega_ClienteId",
                table: "Entrega",
                newName: "IX_Entrega_LugarEntregaId");

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
                name: "FK_Entrega_LugarEntrega_LugarEntregaId",
                table: "Entrega",
                column: "LugarEntregaId",
                principalTable: "LugarEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Entrega_IdEntregaNavigationId",
                table: "Producto",
                column: "IdEntregaNavigationId",
                principalTable: "Entrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Registro_IdRegistroNavigationId",
                table: "Producto",
                column: "IdRegistroNavigationId",
                principalTable: "Registro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_TipoEnvio_IdTipoEnvioNavigationId",
                table: "Producto",
                column: "IdTipoEnvioNavigationId",
                principalTable: "TipoEnvio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
