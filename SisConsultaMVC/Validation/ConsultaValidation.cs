using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisConsultaMVC.Data;
using SisConsultaMVC.Models;

namespace SisConsultaMVC.Validation
{
    public class ConsultaValidation
    {
        private readonly SisConsultaContext _context;

        public ConsultaValidation(SisConsultaContext context)
        {
            _context = context;
        }

        public bool ValidarConsultaMedico(int medicoID, DateTime dataConsulta)
        {            
            return _context.Consultas
                   .Any(m => m.MedicoID == medicoID && (m.DataConsulta <= dataConsulta && m.DataFinalConsulta >= dataConsulta));
        }
    }
}
