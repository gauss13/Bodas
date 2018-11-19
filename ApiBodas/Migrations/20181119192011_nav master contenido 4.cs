using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class navmastercontenido4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MasterFileContenido_ServicioId",
                table: "MasterFileContenido",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterFileContenido_Servicios_ServicioId",
                table: "MasterFileContenido",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterFileContenido_Servicios_ServicioId",
                table: "MasterFileContenido");

            migrationBuilder.DropIndex(
                name: "IX_MasterFileContenido_ServicioId",
                table: "MasterFileContenido");
        }
    }
}
