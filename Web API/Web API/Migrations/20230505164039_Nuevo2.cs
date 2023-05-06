using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API.Migrations
{
    public partial class Nuevo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrendatarioId = table.Column<int>(type: "int", nullable: true),
                    PlazaId = table.Column<int>(type: "int", nullable: true),
                    Confirmada = table.Column<bool>(type: "bit", nullable: true),
                    Contrato = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraFinal = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Plazas_PlazaId",
                        column: x => x.PlazaId,
                        principalTable: "Plazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_ArrendatarioId",
                        column: x => x.ArrendatarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ArrendatarioId",
                table: "Reservas",
                column: "ArrendatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PlazaId",
                table: "Reservas",
                column: "PlazaId");
        }
    }
}
