using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class AgendaTipoCeremonia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_TiposCeremonia_TipoCeremoniaId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "TipoCereminiaId",
                table: "Agendas");

            migrationBuilder.AlterColumn<string>(
                name: "Acronimo",
                table: "EstadosAgenda",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoCeremoniaId",
                table: "Agendas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Agendas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_TiposCeremonia_TipoCeremoniaId",
                table: "Agendas",
                column: "TipoCeremoniaId",
                principalTable: "TiposCeremonia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_TiposCeremonia_TipoCeremoniaId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Agendas");

            migrationBuilder.AlterColumn<string>(
                name: "Acronimo",
                table: "EstadosAgenda",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoCeremoniaId",
                table: "Agendas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TipoCereminiaId",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_TiposCeremonia_TipoCeremoniaId",
                table: "Agendas",
                column: "TipoCeremoniaId",
                principalTable: "TiposCeremonia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
