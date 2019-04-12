using SisConsultaMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataFinalConsulta") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //            entry.Property("DataFinalConsulta").CurrentValue = Convert.ToDateTime(entry.Property("DataConsulta").CurrentValue).AddHours(1);
        //    }
        //    return base.SaveChanges();
        //}
    }
}
