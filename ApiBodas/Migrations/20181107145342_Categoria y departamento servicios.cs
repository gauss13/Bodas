using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class Categoriaydepartamentoservicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_CategoriasServicios_CategoriaServicioId",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "CategoriasServicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_CategoriaServicioId",
                table: "Servicios");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Servicios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Servicios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_CategoriaId",
                table: "Servicios",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Categorias_CategoriaId",
                table: "Servicios",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Categorias_CategoriaId",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_CategoriaId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Paquetes");

            migrationBuilder.CreateTable(
                name: "CategoriasServicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasServicios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_CategoriaServicioId",
                table: "Servicios",
                column: "CategoriaServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_CategoriasServicios_CategoriaServicioId",
                table: "Servicios",
                column: "CategoriaServicioId",
                principalTable: "CategoriasServicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
