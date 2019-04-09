using SisConsultaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SisConsultaMVC.Data
{
    public class SisConsultaContext : DbContext
    {
        public SisConsultaContext(DbContextOptions<SisConsultaContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Medico> Medicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Consulta>().ToTable("Consulta");
            modelBuilder.Entity<Medico>().ToTable("Medico");
        }
    }
}
