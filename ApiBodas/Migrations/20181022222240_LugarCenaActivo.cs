using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBodas.Migrations
{
    public partial class LugarCenaActivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "LugaresCena",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "LugaresCena");
        }
    }
}
