using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class masterFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterFileContenido_Divisas_DivisaId",
                table: "MasterFileContenido");

            migrationBuilder.DropIndex(
                name: "IX_MasterFileContenido_DivisaId",
                table: "MasterFileContenido");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "MasterFile",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "MasterFile");

            migrationBuilder.CreateIndex(
                name: "IX_MasterFileContenido_DivisaId",
                table: "MasterFileContenido",
                column: "DivisaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterFileContenido_Divisas_DivisaId",
                table: "MasterFileContenido",
                column: "DivisaId",
                principalTable: "Divisas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
