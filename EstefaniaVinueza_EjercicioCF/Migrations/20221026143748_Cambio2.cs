using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstefaniaVinueza_EjercicioCF.Migrations
{
    public partial class Cambio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WithTomatoes",
                table: "Pizza",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WithTomatoes",
                table: "Piiza");
        }
    }
}
