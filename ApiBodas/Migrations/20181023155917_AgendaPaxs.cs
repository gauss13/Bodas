using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class AgendaPaxs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaxMenores",
                table: "Agendas",
                newName: "PaxNinos");

            migrationBuilder.RenameColumn(
                name: "PaxBebes",
                table: "Agendas",
                newName: "PaxJunior");

            migrationBuilder.RenameColumn(
                name: "EstadoAgenda",
                table: "Agendas",
                newName: "PaxCunas");

            migrationBuilder.AddColumn<int>(
                name: "AgendaId",
                table: "MasterFile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoAgendaId",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pax3raEdad",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadosAgenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosAgenda", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadosAgenda");

            migrationBuilder.DropColumn(
                name: "AgendaId",
                table: "MasterFile");

            migrationBuilder.DropColumn(
                name: "EstadoAgendaId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Pax3raEdad",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "PaxNinos",
                table: "Agendas",
                newName: "PaxMenores");

            migrationBuilder.RenameColumn(
                name: "PaxJunior",
                table: "Agendas",
                newName: "PaxBebes");

            migrationBuilder.RenameColumn(
                name: "PaxCunas",
                table: "Agendas",
                newName: "EstadoAgenda");
        }
    }
}
