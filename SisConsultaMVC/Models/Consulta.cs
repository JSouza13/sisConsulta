using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisConsultaMVC.Models
{
    public class Consulta
    {
        public int ConsultaID { get; set; }

        [Display(Name = "Médico responsável")]
        public int MedicoID { get; set; }

        [Display(Name = "Paciente")]
        public int PacienteID { get; set; }

        [Display(Name = "Data inicial da consulta")]
        public DateTime DataConsulta { get; set; }

        [Display(Name = "Data final da consulta")]
        public DateTime DataFinalConsulta { get; set; }

        [Display(Name = "Médico responsável")]
        public Medico Medico { get; set; }

        [Display(Name = "Paciente")]
        public Paciente Paciente { get; set; }
    }
}
