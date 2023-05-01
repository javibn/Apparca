using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API.Migrations
{
    public partial class PlazaImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenesPlaza");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Plazas",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "formatoImagen",
                table: "Plazas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Plazas");

            migrationBuilder.DropColumn(
                name: "formatoImagen",
                table: "Plazas");

            migrationBuilder.CreateTable(
                name: "ImagenesPlaza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlazaId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    formatoImagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesPlaza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagenesPlaza_Plazas_PlazaId",
                        column: x => x.PlazaId,
                        principalTable: "Plazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesPlaza_PlazaId",
                table: "ImagenesPlaza",
                column: "PlazaId");
        }
    }
}
