using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class masterfilenotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adicional",
                table: "MasterFileContenido",
                newName: "TieneImagen");

            migrationBuilder.AddColumn<bool>(
                name: "Incluido",
                table: "MasterFileContenido",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nota",
                table: "MasterFileContenido",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nota2",
                table: "MasterFileContenido",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nota3",
                table: "MasterFileContenido",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "MasterFile",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisaId",
                table: "MasterFile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAdicional",
                table: "MasterFile",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalIncuido",
                table: "MasterFile",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMaster",
                table: "MasterFile",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ModuloId",
                table: "Comentarios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Incluido",
                table: "MasterFileContenido");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "MasterFileContenido");

            migrationBuilder.DropColumn(
                name: "Nota2",
                table: "MasterFileContenido");

            migrationBuilder.DropColumn(
                name: "Nota3",
                table: "MasterFileContenido");

            migrationBuilder.DropColumn(
                name: "DivisaId",
                table: "MasterFile");

            migrationBuilder.DropColumn(
                name: "TotalAdicional",
                table: "MasterFile");

            migrationBuilder.DropColumn(
                name: "TotalIncuido",
                table: "MasterFile");

            migrationBuilder.DropColumn(
                name: "TotalMaster",
                table: "MasterFile");

            migrationBuilder.DropColumn(
                name: "ModuloId",
                table: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "TieneImagen",
                table: "MasterFileContenido",
                newName: "Adicional");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "MasterFile",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
