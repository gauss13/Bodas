using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class Categoriaservicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Categorias_CategoriaId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "CategoriaServicioId",
                table: "Servicios");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Servicios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Categorias_CategoriaId",
                table: "Servicios",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Categorias_CategoriaId",
                table: "Servicios");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Servicios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoriaServicioId",
                table: "Servicios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Categorias_CategoriaId",
                table: "Servicios",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
