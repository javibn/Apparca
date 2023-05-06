using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API.Migrations
{
    public partial class Nuevo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plazas_Usuarios_ArrendadorId",
                table: "Plazas");

            migrationBuilder.DropIndex(
                name: "IX_Plazas_ArrendadorId",
                table: "Plazas");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Plazas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plazas_UsuarioId",
                table: "Plazas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plazas_Usuarios_UsuarioId",
                table: "Plazas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plazas_Usuarios_UsuarioId",
                table: "Plazas");

            migrationBuilder.DropIndex(
                name: "IX_Plazas_UsuarioId",
                table: "Plazas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Plazas");

            migrationBuilder.CreateIndex(
                name: "IX_Plazas_ArrendadorId",
                table: "Plazas",
                column: "ArrendadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plazas_Usuarios_ArrendadorId",
                table: "Plazas",
                column: "ArrendadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
