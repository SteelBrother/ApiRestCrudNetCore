using Microsoft.EntityFrameworkCore.Migrations;

namespace TalyCapWEBAPI.Migrations
{
    public partial class Migracion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Cliente_ClienteId",
                table: "Entrega");

            migrationBuilder.DropTable(
                name: "EntregaLugarEntrega");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Entrega");

            migrationBuilder.DropColumn(
                name: "IdVehiculoEntrega",
                table: "Entrega");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Entrega",
                newName: "LugarEntregaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrega_ClienteId",
                table: "Entrega",
                newName: "IX_Entrega_LugarEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_LugarEntrega_LugarEntregaId",
                table: "Entrega",
                column: "LugarEntregaId",
                principalTable: "LugarEntrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_LugarEntrega_LugarEntregaId",
                table: "Entrega");

            migrationBuilder.RenameColumn(
                name: "LugarEntregaId",
                table: "Entrega",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrega_LugarEntregaId",
                table: "Entrega",
                newName: "IX_Entrega_ClienteId");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Entrega",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdVehiculoEntrega",
                table: "Entrega",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
