using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class Paquetedatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "PaqueteServicio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitario",
                table: "PaqueteServicio",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "PaqueteServicio",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DivisaId",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "PaqueteServicio");

            migrationBuilder.DropColumn(
                name: "PrecioUnitario",
                table: "PaqueteServicio");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "PaqueteServicio");

            migrationBuilder.DropColumn(
                name: "DivisaId",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Paquetes");
        }
    }
}
