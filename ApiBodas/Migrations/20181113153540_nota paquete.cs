using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class notapaquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nota",
                table: "Paquetes",
                maxLength: 350,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Paquetes");
        }
    }
}
