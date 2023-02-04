using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPARCA.Migrations
{
    public partial class PlazasSinFechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinal",
                table: "Plazas");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Plazas");

            migrationBuilder.AddColumn<float>(
                name: "PrecioMes",
                table: "Plazas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioMes",
                table: "Plazas");

            migrationBuilder.AddColumn<string>(
                name: "FechaFinal",
                table: "Plazas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaInicio",
                table: "Plazas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
