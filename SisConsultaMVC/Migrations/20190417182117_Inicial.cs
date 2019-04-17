using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisConsultaMVC.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    MedicoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Especialidade = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.MedicoID);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomePaciente = table.Column<string>(maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    NumTelefone = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Rua = table.Column<string>(maxLength: 200, nullable: true),
                    Numero = table.Column<int>(maxLength: 200, nullable: true),
                    Bairro = table.Column<string>(maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteID);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    ConsultaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicoID = table.Column<int>(nullable: false),
                    PacienteID = table.Column<int>(nullable: false),
                    DataConsulta = table.Column<DateTime>(maxLength: 16, nullable: false),
                    DataFinalConsulta = table.Column<DateTime>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.ConsultaID);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medico",
                        principalColumn: "MedicoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Paciente",
                        principalColumn: "PacienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoID",
                table: "Consulta",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteID",
                table: "Consulta",
                column: "PacienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
