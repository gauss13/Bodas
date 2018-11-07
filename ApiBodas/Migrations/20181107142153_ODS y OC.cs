using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class ODSyOC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Adicional",
                table: "MasterFileContenido",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OcRealizado",
                table: "MasterFileContenido",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OcRequerido",
                table: "MasterFileContenido",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adicional",
                table: "MasterFileContenido");

            migrationBuilder.DropColumn(
                name: "OcRealizado",
                table: "MasterFileContenido");

            migrationBuilder.DropColumn(
                name: "OcRequerido",
                table: "MasterFileContenido");
        }
    }
}
