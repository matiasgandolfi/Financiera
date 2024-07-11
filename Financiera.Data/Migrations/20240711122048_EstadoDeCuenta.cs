using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financiera.Data.Migrations
{
    public partial class EstadoDeCuenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Cuentas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Cuentas");
        }
    }
}
