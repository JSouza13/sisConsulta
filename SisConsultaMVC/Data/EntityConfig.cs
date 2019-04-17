using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisConsultaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisConsultaMVC.Data
{
    public class EntityConfig
    {

        public class PacienteMap : IEntityTypeConfiguration<Paciente>
        {
            public void Configure(EntityTypeBuilder<Paciente> builder)
            {
                builder.Property(e => e.NomePaciente)
                    .HasMaxLength(200)
                    .IsRequired();

                builder.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .IsRequired();

                builder.Property(e => e.NumTelefone)
                    .HasMaxLength(14)
                    .IsRequired();

                builder.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsRequired();


                builder.Property(e => e.Rua)
                    .HasMaxLength(200);


                builder.Property(e => e.Numero)
                    .HasMaxLength(200);


                builder.Property(e => e.Bairro)
                    .HasMaxLength(200);


                builder.Property(e => e.Cidade)
                    .HasMaxLength(200);

            }
        }
        public class MedicoMap : IEntityTypeConfiguration<Medico>
        {

            public void Configure(EntityTypeBuilder<Medico> builder)
            {
                builder.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsRequired();

                builder.Property(e => e.Especialidade)
                    .HasMaxLength(200)
                    .IsRequired();

                builder.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsRequired();
            }
        }
        public class ConsultaMap : IEntityTypeConfiguration<Consulta>
        {

            public void Configure(EntityTypeBuilder<Consulta> builder)
            {
                builder.Property(e => e.DataConsulta)
                    .HasMaxLength(16)
                    .IsRequired();

                builder.Property(e => e.DataFinalConsulta)
                    .HasMaxLength(16)
                    .IsRequired();
            }

        }
    }
}
