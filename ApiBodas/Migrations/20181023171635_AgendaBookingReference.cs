using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class AgendaBookingReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingReference",
                table: "Agendas",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DivisaComision",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisaDeposito",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumHabitacion",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingReference",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "DivisaComision",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "DivisaDeposito",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "NumHabitacion",
                table: "Agendas");
        }
    }
}
