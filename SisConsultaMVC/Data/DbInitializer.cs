using SisConsultaMVC.Models;
using System;
using System.Linq;

namespace SisConsultaMVC.Data
{
    public class DbInitializer
    {
        public static void Initialize(SisConsultaContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Pacientes.Any())
            {
                return;   // DB has been seeded
            }

            var pacientes = new Paciente[]
            {
                new Paciente{NomePaciente = "Pedro",
                            Cpf = "215.489.436-49",
                            NumTelefone = "(48)98847-4910",
                            Email = "pedro@gmail.com",
                            Rua = "Rua uruguai",
                            Numero = 666,
                            Bairro = "Nações",
                            Cidade = "Itajai"
                            },
                new Paciente{NomePaciente = "Jonas",
                            Cpf = "338.528.474-00",
                            NumTelefone = "(48)98854-4119",
                            Email = "jonas@gmail.com",
                            Rua = "Rua Paraguai",
                            Numero = 999,
                            Bairro = "Nações",
                            Cidade = "Itajai"
                            },
                //new Paciente{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Paciente s in pacientes)
            {
                context.Pacientes.Add(s);
            }
            context.SaveChanges();

            var medicos = new Medico[]
            {
                new Medico{Nome = "Pedro",
                           Email = "pedro@gmail.com",
                           Especialidade = "Cardiologista"
                 }
            };
            foreach (Medico c in medicos)
            {
                context.Medicos.Add(c);
            }
            context.SaveChanges();

            var consultas = new Consulta[]
            {
                new Consulta{MedicoID = 1, PacienteID = 1, DataConsulta = DateTime.Parse("2005-09-01 15:00:00")}            
            };
            foreach (Consulta e in consultas)
            {
                context.Consultas.Add(e);
            }
            context.SaveChanges();
        }
    }
}
