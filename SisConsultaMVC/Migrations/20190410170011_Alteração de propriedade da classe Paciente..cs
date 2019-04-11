using Microsoft.EntityFrameworkCore.Migrations;

namespace SisConsultaMVC.Migrations
{
    public partial class AlteraçãodepropriedadedaclassePaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Paciente",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
